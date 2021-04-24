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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateIncome(IncomeCreateRequestModel model)
        {
            await _incomeService.CreateIncome(model);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{Id:int}")]
        public async Task<IActionResult> DeleteIncome(int Id)
        {
            await _incomeService.DeleteIncome(Id);
            return Ok();
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateIncome(IncomeUpdateRequestModel model)
        {
            await _incomeService.UpdateIncome(model);
            return Ok();
        }
    }
}
