using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IGenericRepository<Address> _repository;
        public AddressController(IGenericRepository<Address> repository)
        {
            _repository = repository;
        }

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
    }
}
