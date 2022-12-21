using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IGenericRepository<Balance> _repository;
        public BalanceController(IGenericRepository<Balance> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<BalanceModel>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();

            var rViewModel = schedules.Select(x => new BalanceModel
            {
                Debt = x.Debt.ToString(),
                Amount = x.Amount.ToString()
            });

            return rViewModel;
        }

        [HttpPost]
        public async Task Add(BalanceModel balance)
        {
            await _repository.AddAsync(new Balance
            {
                Debt = Decimal.Parse(balance.Debt),
                Amount = Decimal.Parse(balance.Amount)
            });

            await _repository.SaveAsync();
        }
    }
}
