using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySell.Models.ViewModel
{
    public class CatMapSyncViewModel
    {       
            public int id { get; set; }
            public string Cod { get; set; }
            public string Category { get; set; }
            public Nullable<byte> Nivel { get; set; }
            public Nullable<System.DateTime> FechaCreacion { get; set; }
            public Nullable<System.DateTime> FechaEdicion { get; set; }
            public byte[] Image { get; set; }
            public Nullable<bool> CreatedInApp { get; set; }
            public Nullable<bool> Sincronizado { get; set; }
    }
}