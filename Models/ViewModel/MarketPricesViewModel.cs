using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class MarketPricesViewModel
    {
        public byte CompanyID { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<System.DateTime> FechaMP { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
    }
}