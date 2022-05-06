using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class MaintenanceRecordsViewModel
    {
        public short Id { get; set; }
        public string MaintenanceName { get; set; }
        public string Comment { get; set; }
        public Nullable<byte> ModelId { get; set; }
        public Nullable<int> startKm { get; set; }
        public Nullable<int> endKm { get; set; }
        public Nullable<int> NextAfter { get; set; }
        public Nullable<System.DateTime> RecordDate { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<bool> Fulfilled { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
    }
}