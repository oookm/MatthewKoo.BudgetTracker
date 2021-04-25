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
    public class ExpendituresController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;
        public ExpendituresController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExpenditure(ExpenditureCreateRequestModel model)
        {
            await _expenditureService.CreateExpenditure(model);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{Id:int}")]
        public async Task<IActionResult> DeleteExpenditure(int Id)
        {
            await _expenditureService.DeleteExpenditure(Id);
            return Ok();
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateExpenditure(ExpenditureUpdateRequestModel model)
        {
            await _expenditureService.UpdateExpenditure(model);
            return Ok();
        }
        [HttpGet]
        [Route("incomes")]
        public async Task<IActionResult> GetAllExpenditures()
        {
            var expenditures = await _expenditureService.GetAllAsync();
            return Ok(expenditures);
        }
    }
}
