using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var schedules = await _repository.GetAllAsync();

            var rViewModel = schedules.Select(x => new DepartmentModel
            {
                Name = x.Name,
                MaxNumbOfStudents = x.MaxNumbOfStudents.ToString(),
                CurrentAmount = x.CurrentAmount.ToString()
            });

            return rViewModel;
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
    }
}
