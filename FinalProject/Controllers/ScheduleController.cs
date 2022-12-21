using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IGenericRepository<Schedule> _repository;


        public ScheduleController(IGenericRepository<Schedule> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ScheduleModel>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();

            var rViewModel = schedules.Select(x => new ScheduleModel
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime
            });

            return rViewModel;
        }

        [HttpPost]
        public async Task Add(ScheduleModel schedule)
        {
            await _repository.AddAsync(new Schedule
            {
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime
            });
            await _repository.SaveAsync();
        }
    }
}
