using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class BankBalanceViewModel
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