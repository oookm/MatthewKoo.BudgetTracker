using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task<bool> CreateIncome(IncomeCreateRequestModel model);
        Task<bool> DeleteIncome(int incomeId);
        Task<bool> UpdateIncome(IncomeUpdateRequestModel model);
    }
}
