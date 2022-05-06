using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class PurchasedItemsSyncViewModel
    {
        public int id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<decimal> PurchaseQuantity { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public string Observations { get; set; }
        public string MPurchased { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<short> YPurchased { get; set; }
        public Nullable<bool> PurchasedInApp { get; set; }
        public Nullable<bool> Sincronizado { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
    }
}