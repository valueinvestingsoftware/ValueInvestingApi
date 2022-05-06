using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SoldItemsViewModel
    {
        public int id { get; set; }
        public Nullable<int> itemid { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<decimal> SaleQuantity { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string dia { get; set; }
        public Nullable<byte> DiaNumber { get; set; }
        public Nullable<decimal> Profit { get; set; }
        public string MSold { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<short> YSold { get; set; }
    }
}