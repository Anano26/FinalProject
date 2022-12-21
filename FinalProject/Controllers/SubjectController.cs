using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IGenericRepository<Subject> _repository;


        public SubjectController(IGenericRepository<Subject> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectModel>> GetAllAsync()
        {
            var Subjects = await _repository.GetAllAsync();

            var rViewModel = Subjects.Select(x => new SubjectModel
            {
                Name = x.Name,
                Credit = x.Credit.ToString(),
                LowerBound = x.Credit.ToString()
            });

            return rViewModel;
        }

        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
        }


        [HttpPost]
        public async Task Add(SubjectModel subject)
        {
            await _repository.AddAsync(new Subject
            {
                Name = subject.Name,
                Credit = Int32.Parse(subject.Credit),
                LowerBound = Int32.Parse(subject.LowerBound)

            });
            await _repository.SaveAsync();
        }
    }
}
