using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IGenericRepository<StudentSubject> _repository;


        public StudentSubjectController(IGenericRepository<StudentSubject> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentSubjectModel>> GetAllAsync()
        {
            var StudentSubjects = await _repository.GetAllAsync();

            var rViewModel = StudentSubjects.Select(x => new StudentSubjectModel
            {
                Point = x.Point.ToString()
            });

            return rViewModel;
        }

        [HttpPost]
        public async Task Add(StudentSubjectModel studentSubject)
        {
            await _repository.AddAsync(new StudentSubject
            {
                Point = Int32.Parse(studentSubject.Point)
            });
            await _repository.SaveAsync();
        }
    }
}
