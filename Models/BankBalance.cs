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
    
    public partial class BankBalance
    {
        public long Id { get; set; }
        public Nullable<byte> BankId { get; set; }
        public string Operation { get; set; }
        public Nullable<decimal> Value { get; set; }
        public string Comment { get; set; }
        public string MSpences { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<short> YSpences { get; set; }
        public Nullable<System.DateTime> RecordDate { get; set; }
        public Nullable<System.DateTime> LastEditDale { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<bool> GetDebitNumber_AfterSync { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
        public string DebitUniqueIdentifier { get; set; }
    }
}