//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuySell.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Companies
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
