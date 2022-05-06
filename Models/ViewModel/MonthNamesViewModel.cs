using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class MonthNamesViewModel
    {
        public byte id { get; set; }
        public Nullable<byte> LanguageId { get; set; }
        public Nullable<byte> MonthNumber { get; set; }
        public string MonthName { get; set; }
    }
}