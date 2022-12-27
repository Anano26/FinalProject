using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IGenericRepository<Room> _repository;
        public RoomController(IGenericRepository<Room> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all rooms
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();

            var rViewModel = schedules.Select(x => new RoomModel
            {
                Description = x.Description,
                IsFree = x.IsFree.ToString(),
                MaxNumberOfStudents = x.MaxNumberOfStudents.ToString()
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one room
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("id={id}")]
        public async Task<RoomModel> GetById(int id)
        {
            var balance = await _repository.GetByIdAsync(id);

            return new RoomModel
            {
                Description = balance.Description,
                IsFree = balance.IsFree.ToString(),
                MaxNumberOfStudents = balance.MaxNumberOfStudents.ToString()
            };
        }

        /// <summary>
        /// Adds one room
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(RoomModel room)
        {
            await _repository.AddAsync(new Room
            {
                Description = room.Description,
                IsFree = Boolean.Parse(room.IsFree),
                MaxNumberOfStudents = Int32.Parse(room.MaxNumberOfStudents)
            });

            await _repository.SaveAsync();
        }

        /// <summary>
        /// Adds multiple rooms
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("~/AddManyRooms")]
        public async Task Add(List<RoomModel> rooms)
        {
            rooms.ForEach(x => _repository.AddAsync(new Room
            {
                Description = x.Description,
                IsFree = Boolean.Parse(x.IsFree),
                MaxNumberOfStudents = Int32.Parse(x.MaxNumberOfStudents)
            }));

            await _repository.SaveAsync();
        }

        /// <summary>
        /// Delete one room
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }
    }
}
