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
    }
}
