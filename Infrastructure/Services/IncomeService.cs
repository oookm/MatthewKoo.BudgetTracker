using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces;
using MatthewKoo.BudgetTracker.ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Response;

namespace MatthewKoo.BudgetTracker.Infrastructure.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IAsyncRepository<Income> _incomeRepository;
        public IncomeService(IAsyncRepository<Income> incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public async Task<bool> CreateIncome(IncomeCreateRequestModel model)
        {
            var income = new Income
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            await _incomeRepository.AddAsync(income);
            return true;
        }

        public async Task<bool> DeleteIncome(int incomeId)
        {
            var income = await _incomeRepository.GetByIdAsync(incomeId);
            if (income == null)
            {
                throw new NotFoundException("Income Not Found");
            }
            await _incomeRepository.DeleteAsync(income);
            return true;
        }

        public async Task<bool> UpdateIncome(IncomeUpdateRequestModel model)
        {
            var updatedIncome = new Income
            {
                Id = model.Id,
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            await _incomeRepository.UpdateAsync(updatedIncome);
            return true;
        }

        public async Task<List<IncomeResponseModel>> GetAllAsync()
        {
            var incomes = await _incomeRepository.ListAllAsync();
            var result = new List<IncomeResponseModel>();

            foreach (var income in incomes)
            {
                result.Add(
                    new IncomeResponseModel
                    {
                        Amount = income.Amount,
                        Description = income.Description,
                        Id = income.Id,
                        IncomeDate = income.IncomeDate,
                        Remarks = income.Remarks,
                        UserId = income.UserId, 
                    });
            }

            return result;
        }
    }
}
