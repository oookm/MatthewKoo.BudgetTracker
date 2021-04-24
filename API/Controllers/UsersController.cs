using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Models.Request;
using MatthewKoo.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // get the userresponsemodel with just the user details
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        // get user and corresponding expenditures/incomes
        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetAllUsersWithDetails(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            return Ok(user);
        }
        // take in a createrequest model and make a user
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser(UserCreateRequestModel user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestModel model)
        {
            await _userService.UpdateUser(model);
            return Ok();
        }
    }
}
