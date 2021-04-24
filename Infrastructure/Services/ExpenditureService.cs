using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Exceptions;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.Infrastructure.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IAsyncRepository<Expenditure> _expenditureRepository;
        public ExpenditureService(IAsyncRepository<Expenditure> expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }
        public async Task<bool> CreateExpenditure(ExpenditureCreateRequestModel model)
        {
            var expenditure = new Expenditure
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            await _expenditureRepository.AddAsync(expenditure);
            return true;
        }

        public async Task<bool> DeleteExpenditure(int expenditureId)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(expenditureId);
            if (expenditure == null)
            {
                throw new NotFoundException("Expenditure Not Found");
            }
            await _expenditureRepository.DeleteAsync(expenditure);
            return true;
        }

        public async Task<bool> UpdateExpenditure(ExpenditureUpdateRequestModel model)
        {
            var updatedExpenditure = new Expenditure
            {
                Id = model.Id,
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            await _expenditureRepository.UpdateAsync(updatedExpenditure);
            return true;
        }
    }
}
