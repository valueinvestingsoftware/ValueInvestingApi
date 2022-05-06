using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class ParametersViewModel
    {
        public int id { get; set; }
        public Nullable<short> Year { get; set; }
        public string Month { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<decimal> MonthlySavings { get; set; }
        public Nullable<decimal> MonthlyIncome { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
    }
}