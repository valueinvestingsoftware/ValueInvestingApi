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
    
    public partial class MarketPrices
    {
        public byte CompanyID { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<System.DateTime> FechaMP { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
    }
}
