using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SoldItemsSyncViewModel
    {
        public long id { get; set; }
        public Nullable<int> itemid { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<decimal> SaleQuantity { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string dia { get; set; }
        public Nullable<byte> DiaNumber { get; set; }
        public string Observations { get; set; }
        public Nullable<decimal> Profit { get; set; }
        public string MSold { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<short> YSold { get; set; }
        public Nullable<bool> SoldInApp { get; set; }
        public Nullable<bool> Sincronizado { get; set; }
        public Nullable<byte> CodVendedor { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
    }
}