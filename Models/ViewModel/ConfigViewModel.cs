using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class ConfigViewModel
    {
        public byte id { get; set; }
        public Nullable<byte> ItemLevels { get; set; }
        public string CountryCode { get; set; }
    }
}