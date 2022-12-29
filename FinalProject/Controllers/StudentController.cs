using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IGenericRepository<Student> _repository;


        public StudentController(IGenericRepository<Student> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all students
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            var Students = await _repository.GetAllAsync();

            var rViewModel = Students.Select(x => new StudentModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalId = x.PersonalId,
                StartYear = x.StartYear.ToString()
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one student
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<StudentModel> GetOne(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            return new StudentModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PersonalId = student.PersonalId,
                StartYear = student.StartYear.ToString()
            };
        }

        /// <summary>
        /// Add one student
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(StudentModel student)
        {
            await _repository.AddAsync(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PersonalId = student.PersonalId,
                StartYear = Int32.Parse(student.StartYear)
            });
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Delete one student
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }


        /// <summary>
        /// Adds an address to a student
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("/AddOrChangeStudentAddress")]
        public async Task AddOrChangeStudentAddress(int studentId, AddressModel addressModel)
        {
            var student = await  _repository.GetByIdAsync(studentId);

            Address address = new Address
            {
                Address1 = addressModel.Address1,
                Address2 = addressModel.Address2
            };

            student.Address = address;

            _repository.Update(student);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// Gets the address of a teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("~/GetStudentAddress")]
        public async Task<AddressModel> GetStudentAddress(int studentId)
        {
            var student = await _repository.GetByIdAsync(studentId);

            if (student.Address == null) return null;

            return new AddressModel
            {
                Address1 = student.Address.Address1,
                Address2 = student.Address.Address2
            };
        }
    }
}
