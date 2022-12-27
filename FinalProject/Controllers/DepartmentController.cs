using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    //This controller is done, add xmls

    [ApiController]
    [Route("department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericRepository<Department> _repository;
        public DepartmentController(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all departments
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets one department
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add one department
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes one department
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete("/department/delete/id={id}")]
        public async void DeleteOne(int id)
        {
            _repository.Delete(id);
            await _repository.SaveAsync();
        }
    }
}
