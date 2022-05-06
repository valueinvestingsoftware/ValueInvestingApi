using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class CarModelsViewModel
    {
        public byte Id { get; set; }
        public string Brand { get; set; }
        public Nullable<int> CurrentMilleage { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
    }
}