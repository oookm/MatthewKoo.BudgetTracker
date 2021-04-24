using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Exceptions;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Response;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // get all the users and their details only
        public async Task<List<UserResponseModel>> GetAllAsync()
        {
            var users = await _userRepository.ListAllAsync();
            var result = new List<UserResponseModel>();
            
            foreach (var user in users)
            {
                result.Add(
                    new UserResponseModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Password = user.Password,
                        Fullname = user.Fullname,
                        JoinedOn = user.JoinedOn
                    });
            }

            return result;
        }

        // get all the details for one users
        public async Task<UserDetailsResponseModel> GetUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            var expenditures = new List<ExpenditureResponseModel>();
            var incomes = new List<IncomeResponseModel>();
            // map database expenditure values to model
            foreach(var expenditure in user.Expenditures)
            {
                expenditures.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            foreach(var income in user.Incomes)
            {
                incomes.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            var response = new UserDetailsResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Fullname = user.Fullname,
                JoinedOn = user.JoinedOn,
                Expenditures = expenditures,
                Incomes = incomes
            };
            return response;
        }
        public async Task<bool> CreateUser(UserCreateRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                JoinedOn = model.JoinedOn
            };
            var createduser = await _userRepository.AddAsync(user);
            return true;
        }
        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            await _userRepository.DeleteAsync(user);
            return true;
        }
        public async Task<bool> UpdateUser(UserUpdateRequestModel model)
        {
            var updatedUser = new User
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                JoinedOn = model.JoinedOn
            };
            await _userRepository.UpdateAsync(updatedUser);
            return true;
        }
    }
}
