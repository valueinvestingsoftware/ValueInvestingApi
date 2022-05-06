using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class CompaniesViewModel
    {
        public short CompanyId { get; set; }
        public string Company { get; set; }
        public Nullable<decimal> RealPrice { get; set; }
        public Nullable<decimal> Ponderated { get; set; }
        public Nullable<short> Ranking { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public string Exclude { get; set; }
        public byte[] Image { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
    }
}