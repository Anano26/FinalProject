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
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Address> _addressRepository;


        public TeacherController(IGenericRepository<Teacher> repository
                                , IGenericRepository<Address> addressRepository)
        {
            _teacherRepository = repository;
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet(Name = "GetAll", Order = 1)]
        public async Task<IEnumerable<TeacherModel>> GetAllAsync()
        {
            var Teachers = await _teacherRepository.GetAllAsync();

            var rViewModel = Teachers.Select(x => new TeacherModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalId = x.PersonalId
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TeacherModel> GetOne(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            return new TeacherModel
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PersonalId = teacher.PersonalId
            };
        }

        /// <summary>
        /// Adds a teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(TeacherModel teacher)
        {
            await _teacherRepository.AddAsync(new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PersonalId = teacher.PersonalId
            });
            await _teacherRepository.SaveAsync();
        }

        /// <summary>
        /// Adds an address to a teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("/AddOrChangeTeacherAddress")]
        public async Task AddOrChangeAddress(int teacherId, AddressModel addressModel)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(teacherId);

            Address address = new Address
            {
                Address1 = addressModel.Address1,
                Address2 = addressModel.Address2
            };

            teacher.Address = address;

            _teacherRepository.Update(teacher);

            await _teacherRepository.SaveAsync();
        }

        /// <summary>
        /// Gets the address of a teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("~/GetTeacherAddress")]
        public async Task<AddressModel> GetTeacherAddress(int teacherId)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(teacherId);

            if (teacher.Address == null) return null;

            return new AddressModel
            {
                Address1 = teacher.Address.Address1,
                Address2 = teacher.Address.Address2
            };
        }

        /// <summary>
        /// Deletes one teacher
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _teacherRepository.Delete(id);
        }
    }
}
