using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class SyncAuditViewModel
    {
        public byte id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
    }
}