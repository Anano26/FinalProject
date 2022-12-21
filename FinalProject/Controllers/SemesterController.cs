using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SemesterController : ControllerBase
    {
        private readonly IGenericRepository<Semester> _repository;


        public SemesterController(IGenericRepository<Semester> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IEnumerable<SemesterModel>> GetAllAsync()
        {
            var Semesters = await _repository.GetAllAsync();

            var rViewModel = Semesters.Select(x => new SemesterModel
            {
                Name = x.Name,
                StartDate = x.StartDate,
                AvailableGPA = x.AvailableGPA.ToString(),
                EndDate = x.EndDate,
            });

            return rViewModel;
        }

        [HttpGet("{id}")]
        public async Task<SemesterModel> GetOne(int id)
        {
            var semester = await _repository.GetByIdAsync(id);

            return new SemesterModel
            {
                Name = semester.Name,
                StartDate = semester.StartDate,
                AvailableGPA = semester.AvailableGPA.ToString(),
                EndDate = semester.EndDate,
            };
        }

        [HttpGet("~/GetFirst")]
        public async Task<SemesterModel> GetFirst()
        {
            var Semesters = await _repository.GetAllAsync();

            var firstSemester = Semesters.First();

            return new SemesterModel
            {
                Name = firstSemester.Name,
                StartDate = firstSemester.StartDate,
                AvailableGPA = firstSemester.AvailableGPA.ToString(),
                EndDate = firstSemester.EndDate,
            };

        }

        [HttpPost]
        public async Task Add(SemesterModel semester)
        {
            await _repository.AddAsync(new Semester
            {
                Name = semester.Name,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate,
                AvailableGPA = Int32.Parse(semester.AvailableGPA)
            });
            await _repository.SaveAsync();
        }



    }
}
