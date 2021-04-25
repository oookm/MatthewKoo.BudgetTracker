using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task<bool> CreateExpenditure(ExpenditureCreateRequestModel model);
        Task<bool> DeleteExpenditure(int expenditureId);
        Task<bool> UpdateExpenditure(ExpenditureUpdateRequestModel model);
        Task<List<ExpenditureResponseModel>> GetAllAsync();
    }
}
