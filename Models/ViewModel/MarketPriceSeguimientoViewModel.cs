using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class MarketPriceSeguimientoViewModel
    {
        public int id { get; set; }
        public Nullable<byte> CompanyId { get; set; }
        public Nullable<System.DateTime> Day { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<System.DateTime> RecordedDateAndTime { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
    }
}