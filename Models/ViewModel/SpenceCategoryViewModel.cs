using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SpenceCategoryViewModel
    {
        public byte SpenceID { get; set; }
        public string SpenceDescription { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
        public Nullable<bool> Hidden { get; set; }
    }
}