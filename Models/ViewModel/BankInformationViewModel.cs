using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class BankInformationViewModel
    {
        public byte Id { get; set; }
        public string BankName { get; set; }
        public Nullable<decimal> InitialBalance { get; set; }
    }
}