using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SpencesViewModel
    {
        public long id { get; set; }
        public Nullable<byte> SpenceId { get; set; }
        public Nullable<decimal> Spence { get; set; }
        public Nullable<System.DateTime> DSpences { get; set; }
        public string dia { get; set; }
        public Nullable<byte> DiaNumber { get; set; }
        public Nullable<byte> DiaSpences { get; set; }
        public string MSpences { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public Nullable<short> YSpences { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
        public Nullable<bool> BankDebit { get; set; }
        public Nullable<bool> SelfLoans_AfterSync { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
        public string DebitUniqueIdentifier { get; set; }
    }
}