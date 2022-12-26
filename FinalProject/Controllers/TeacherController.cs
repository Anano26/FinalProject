using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IGenericRepository<Teacher> _repository;


        public TeacherController(IGenericRepository<Teacher> repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAll", Order = 1)]
        public async Task<IEnumerable<TeacherModel>> GetAllAsync()
        {
            var Teachers = await _repository.GetAllAsync();

            var rViewModel = Teachers.Select(x => new TeacherModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalId = x.PersonalId
            });

            return rViewModel;
        }

        [HttpGet("{id}")]
        public async Task<TeacherModel> GetOne(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);

            return new TeacherModel
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PersonalId = teacher.PersonalId
            };
        }

        [HttpPost]
        public async Task Add(TeacherModel teacher)
        {
            await _repository.AddAsync(new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PersonalId = teacher.PersonalId
            });
            await _repository.SaveAsync();
        }

        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
        }
    }
}
