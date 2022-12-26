using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericRepository<Department> _repository;
        public DepartmentController(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();

            var rViewModel = departments.Select(x => new DepartmentModel
            {
                Name = x.Name,
                MaxNumbOfStudents = x.MaxNumbOfStudents.ToString(),
                CurrentAmount = x.CurrentAmount.ToString()
            });

            return rViewModel;
        }

        [HttpGet("name={name}")]
        public async Task<IEnumerable<DepartmentModel>> GetByName(string name)
        {
            var departments = await _repository.GetAllAsync(x => x.Name == name);

            var rViewModel = departments.Select(x => new DepartmentModel
            {
                Name = x.Name,
                MaxNumbOfStudents = x.MaxNumbOfStudents.ToString(),
                CurrentAmount = x.CurrentAmount.ToString()
            });

            return rViewModel;
        }

        [HttpGet("id={id}")]
        public async Task<DepartmentModel> GetById(int id)
        {
            var department = await _repository.GetByIdAsync(id);

            return new DepartmentModel
            {
                Name = department.Name,
                MaxNumbOfStudents = department.MaxNumbOfStudents.ToString(),
                CurrentAmount = department.CurrentAmount.ToString()
            };
        }

        [HttpPost]
        public async Task Add(DepartmentModel department)
        {
            await _repository.AddAsync(new Department
            {
                Name = department.Name,
                MaxNumbOfStudents = Int32.Parse(department.MaxNumbOfStudents),
                CurrentAmount = Int32.Parse(department.CurrentAmount)
            });

            await _repository.SaveAsync();
        }

        [HttpDelete("/department/delete/id={id}")]
        public void DeleteOne(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }
    }
}
