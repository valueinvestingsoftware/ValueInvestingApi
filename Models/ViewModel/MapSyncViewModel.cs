using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class MapSyncViewModel
    {
        public int id { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public string Contacto { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> telefono { get; set; }
        public string email { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaEdicion { get; set; }
        public Nullable<bool> CreatedInApp { get; set; }
        public Nullable<bool> Sincronizado { get; set; }
        public byte[] Image { get; set; }
        public Nullable<System.DateTime> FechaSync { get; set; }
    }
}