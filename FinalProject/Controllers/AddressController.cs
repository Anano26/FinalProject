using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly IGenericRepository<Address> _repository;
        public AddressController(IGenericRepository<Address> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all adresses
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AddressModel>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();

            var rViewModel = schedules.Select(x => new AddressModel
            {
                Address1 = x.Address1,
                Address2 = x.Address2
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one adress
        /// </summary>
        /// <param>address id</param>
        /// <returns></returns>
        [HttpGet("id={id}")]
        public async Task<AddressModel> GetById(int id)
        {
            var address = await _repository.GetByIdAsync(id);

            return new AddressModel
            {
                Address1 = address.Address1,
                Address2 = address.Address2
            };
        }

        /// <summary>
        /// Adds one adress
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(AddressModel address)
        {
            await _repository.AddAsync(new Address
            {
                Address1 = address.Address1,
                Address2 = address.Address2
            });

            await _repository.SaveAsync();
        }
        /// <summary>
        /// Deletes one adress
        /// </summary>
        /// <param>address id</param>
        /// <returns></returns>
        [HttpDelete]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }
    }
}
