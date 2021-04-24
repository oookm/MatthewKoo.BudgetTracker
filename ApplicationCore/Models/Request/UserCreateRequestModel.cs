using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.Models.Request
{
    public class UserCreateRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
