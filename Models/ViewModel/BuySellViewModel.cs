using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class BuySellViewModel
    {
        public int id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string Cod { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> PurchaseQuantity { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> SaleQuantity { get; set; }
        public Nullable<decimal> AvailableQuantity { get; set; }
        public string Clase { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Tipo { get; set; }
        public string SubTipo { get; set; }
        public Nullable<decimal> Profit { get; set; }
    }
}