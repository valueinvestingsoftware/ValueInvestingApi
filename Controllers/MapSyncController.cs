using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BuySell.Controllers
{
    public class MapSyncController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.MapSyncViewModel modelMapSync)
        {
            using (MapSyncEntities db = new MapSyncEntities())
            {
                var oMapSync = new Map_Sync();
                oMapSync.id = modelMapSync.id;
                oMapSync.Supplier = modelMapSync.Supplier;
                oMapSync.Contacto = modelMapSync.Contacto;
                oMapSync.Address = modelMapSync.Address;
                oMapSync.City = modelMapSync.City;
                oMapSync.telefono = modelMapSync.telefono;
                oMapSync.email = modelMapSync.email;
                oMapSync.Valor = modelMapSync.Valor;
                oMapSync.Latitud = modelMapSync.Latitud;
                oMapSync.Longitud = modelMapSync.Longitud;
                oMapSync.Comment = modelMapSync.Comment;
                oMapSync.FechaCreacion = modelMapSync.FechaCreacion;
                oMapSync.FechaEdicion = modelMapSync.FechaEdicion;
                oMapSync.CreatedInApp = modelMapSync.CreatedInApp;
                oMapSync.Sincronizado = modelMapSync.Sincronizado;
                oMapSync.Image = modelMapSync.Image;
                oMapSync.FechaSync = modelMapSync.FechaSync;

                db.Map_Sync.Add(oMapSync);
                db.SaveChanges();
                
             }
            return Ok("Exito");
        }

        private MapSyncEntities db = new MapSyncEntities();
        //Get Api/MapSync
        public IQueryable<Map_Sync> Get()
        {
            return db.Map_Sync;
        }

        //GET api/MapSync/5
        [ResponseType(typeof(Map_Sync))]
        public IHttpActionResult Get(int id)
        {
            var mapsync = db.Map_Sync.Find(id);
            if (mapsync == null)
            {
                return NotFound();
            }

            return Ok(mapsync);
        }
    }
}


