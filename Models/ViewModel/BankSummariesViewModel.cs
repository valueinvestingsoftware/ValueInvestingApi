using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class BankSummariesViewModel
    {
        public int id { get; set; }
        public Nullable<byte> bankId { get; set; }
        public Nullable<short> YSpences { get; set; }
        public Nullable<decimal> balance { get; set; }
        public string MonthName { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
    }
}