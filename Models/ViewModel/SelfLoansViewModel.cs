using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SelfLoansViewModel
    {
        public byte LoanId { get; set; }
        public string LoanDescription { get; set; }
        public Nullable<System.DateTime> LoanDate { get; set; }
        public Nullable<byte> NumberOfInstallments { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AlreadyPayed { get; set; }
        public Nullable<decimal> YourCurrentDebt { get; set; }
        public Nullable<decimal> EachInstallment { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
    }
}