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
    public class CatMapSyncController : ApiController
    {   

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.CatMapSyncViewModel modelCatMapSync)
        {
            using (CatMapSyncEntities db = new CatMapSyncEntities())
            {
                var oCatMapItemsSync = new Models.CatMap_Sync();
                oCatMapItemsSync.id = modelCatMapSync.id;
                oCatMapItemsSync.Cod = modelCatMapSync.Cod;
                oCatMapItemsSync.Category = modelCatMapSync.Category;
                oCatMapItemsSync.Nivel = modelCatMapSync.Nivel;
                oCatMapItemsSync.FechaCreacion = modelCatMapSync.FechaCreacion;
                oCatMapItemsSync.FechaEdicion = modelCatMapSync.FechaEdicion;
                oCatMapItemsSync.Image = modelCatMapSync.Image;
                oCatMapItemsSync.CreatedInApp = modelCatMapSync.CreatedInApp;
                oCatMapItemsSync.Sincronizado = modelCatMapSync.Sincronizado;

                db.CatMap_Sync.Add(oCatMapItemsSync);
                db.SaveChanges();

            }
            return Ok("Exito");
        }

        private CatMapSyncEntities db = new CatMapSyncEntities();
        //Get Api/CatMapSync
        public IQueryable<CatMap_Sync> Get()
        {
            return db.CatMap_Sync;
        }

        //GET api/CatMapSync/5
        [ResponseType(typeof(CatMap_Sync))]
        public IHttpActionResult Get(int id)
        {
            var catmapsync = db.CatMap_Sync.Find(id);
            if (catmapsync == null)
            {
                return NotFound();
            }

            return Ok(catmapsync);
        }
    }
}
