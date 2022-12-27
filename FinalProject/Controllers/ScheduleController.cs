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

        /// <summary>
        /// Gets all schedule entries
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets one schedule entry by id
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("id={id}")]
        public async Task<ScheduleModel> GetById(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);

            return new ScheduleModel
            {
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime
            };
        }

        /// <summary>
        /// Add one schedule entry
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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

        ///// <summary>
        ///// Add many schedule entries
        ///// </summary>
        ///// <param></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task Add(List<ScheduleModel> schedules)
        //{
        //    await _repository.AddAsync(new Schedule
        //    {
        //        StartTime = schedule.StartTime,
        //        EndTime = schedule.EndTime
        //    });
        //    await _repository.SaveAsync();
        //}

        /// <summary>
        /// Delete one schedule entry
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
