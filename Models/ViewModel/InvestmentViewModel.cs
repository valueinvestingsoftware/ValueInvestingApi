using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class InvestmentViewModel
    {
        public byte CompanyId { get; set; }
        public Nullable<int> TotalOwned { get; set; }
        public Nullable<decimal> PrecioPromedioCompra { get; set; }
        public Nullable<decimal> Dinero { get; set; }
        public Nullable<int> SoloCompradas { get; set; }
        public Nullable<int> SoloVendidas { get; set; }
        public Nullable<decimal> UtilidadBancaria { get; set; }
        public Nullable<decimal> UtilidadAccion { get; set; }
        public Nullable<decimal> ComisionCompra { get; set; }
        public Nullable<decimal> ComisionVenta { get; set; }
    }
}