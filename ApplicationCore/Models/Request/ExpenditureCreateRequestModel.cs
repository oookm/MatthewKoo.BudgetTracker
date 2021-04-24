﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.ApplicationCore.Models.Request
{
    public class ExpenditureCreateRequestModel
    {
        public int? UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
    }
}