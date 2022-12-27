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

        /// <summary>
        /// Gets all semesters
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IEnumerable<SemesterModel>> GetAllAsync()
        {
            var semesters = await _repository.GetAllAsync();

            var rViewModel = semesters.Select(x => new SemesterModel
            {
                Name = x.Name,
                StartDate = x.StartDate,
                AvailableGPA = x.AvailableGPA.ToString(),
                EndDate = x.EndDate,
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one semester
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds one semester
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete one semester
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete]
        public void DeleteOne(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }
    }
}
