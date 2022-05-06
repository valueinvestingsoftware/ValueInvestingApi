using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class DividendosViewModel
    {
        public int id { get; set; }
        public byte CompanyID { get; set; }
        public short Year { get; set; }
        public Nullable<decimal> DividendosEfectivo { get; set; }
        public Nullable<decimal> DividendosAccion { get; set; }
        public Nullable<int> AccionesPrecedentes { get; set; }
        public Nullable<decimal> AccionesPorAccion { get; set; }
        public Nullable<decimal> EfectivoPorAccion { get; set; }
        public string Distribute { get; set; }
        public string Graph { get; set; }
        public Nullable<decimal> AvSalePrice { get; set; }
    }
}