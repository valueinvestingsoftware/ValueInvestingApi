using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class PricesViewModel
    {
        public int id { get; set; }
        public Nullable<byte> PriceListId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}