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
    public class SoldItemsSyncController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.SoldItemsSyncViewModel modelSoldItemsSync)
        {
            using (Models.SoldItemsSyncEntities db = new Models.SoldItemsSyncEntities())
            {
                var oSoldItemsSync = new Models.SoldItems_Sync();

                oSoldItemsSync.id = modelSoldItemsSync.id;
                oSoldItemsSync.itemid = modelSoldItemsSync.itemid;
                oSoldItemsSync.ClientId = modelSoldItemsSync.ClientId;
                oSoldItemsSync.SaleQuantity = modelSoldItemsSync.SaleQuantity;
                oSoldItemsSync.SalePrice = modelSoldItemsSync.SalePrice;
                oSoldItemsSync.SaleDate = modelSoldItemsSync.SaleDate;
                oSoldItemsSync.dia = modelSoldItemsSync.dia;
                oSoldItemsSync.DiaNumber = modelSoldItemsSync.DiaNumber;
                oSoldItemsSync.Observations = modelSoldItemsSync.Observations;
                oSoldItemsSync.Profit = modelSoldItemsSync.Profit;
                oSoldItemsSync.MSold = modelSoldItemsSync.MSold;
                oSoldItemsSync.MonthNumber = modelSoldItemsSync.MonthNumber;
                oSoldItemsSync.YSold = modelSoldItemsSync.YSold;
                oSoldItemsSync.SoldInApp = modelSoldItemsSync.SoldInApp;
                oSoldItemsSync.Sincronizado = modelSoldItemsSync.Sincronizado;
                oSoldItemsSync.CodVendedor = modelSoldItemsSync.CodVendedor;
                oSoldItemsSync.FechaSync = modelSoldItemsSync.FechaSync;

                db.SoldItems_Sync.Add(oSoldItemsSync);
                db.SaveChanges();

            }
            return Ok("Exito");
        }


        private SoldItemsSyncEntities db = new SoldItemsSyncEntities();
        //Get Api/SoldItemsSync
        public IQueryable<SoldItems_Sync> Get()
        {
            return db.SoldItems_Sync;
        }

        //GET api/CatMapSync/5
        [ResponseType(typeof(SoldItems_Sync))]
        public IHttpActionResult Get(int id)
        {
            var solditemssync = db.SoldItems_Sync.Find(id);
            if (solditemssync == null)
            {
                return NotFound();
            }

            return Ok(solditemssync);
        }
    }
}

