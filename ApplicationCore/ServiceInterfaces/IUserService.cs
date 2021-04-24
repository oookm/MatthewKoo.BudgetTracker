using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAllAsync();
        Task<UserDetailsResponseModel> GetUserAsync(int userId);
        Task<bool> CreateUser(UserCreateRequestModel model);
        Task<bool> DeleteUser(int userId);
        Task<bool> UpdateUser(UserUpdateRequestModel model);
    }
}
