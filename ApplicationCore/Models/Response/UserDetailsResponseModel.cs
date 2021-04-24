using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.Models.Response
{
    public class UserDetailsResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
        public List<ExpenditureResponseModel> Expenditures { get; set; }
        public List<IncomeResponseModel> Incomes { get; set; }
    }
}
