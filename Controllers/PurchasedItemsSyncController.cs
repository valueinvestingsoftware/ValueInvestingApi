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
    public class PurchasedItemsSyncController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.PurchasedItemsSyncViewModel modelPurchasedItemsSync)
        {
            using (Models.PurchasedItemsSyncEntities db = new Models.PurchasedItemsSyncEntities())
            {
                var oPurchasedItemsSync = new Models.PurchasedItems_Sync();
                oPurchasedItemsSync.id = modelPurchasedItemsSync.id;
                oPurchasedItemsSync.ItemId = modelPurchasedItemsSync.ItemId;
                oPurchasedItemsSync.SupplierId = modelPurchasedItemsSync.SupplierId;
                oPurchasedItemsSync.PurchaseQuantity = modelPurchasedItemsSync.PurchaseQuantity;
                oPurchasedItemsSync.PurchasePrice = modelPurchasedItemsSync.PurchasePrice;
                oPurchasedItemsSync.PurchaseDate = modelPurchasedItemsSync.PurchaseDate;
                oPurchasedItemsSync.Observations = modelPurchasedItemsSync.Observations;
                oPurchasedItemsSync.MPurchased = modelPurchasedItemsSync.MPurchased;
                oPurchasedItemsSync.MonthNumber = modelPurchasedItemsSync.MonthNumber;
                oPurchasedItemsSync.YPurchased = modelPurchasedItemsSync.YPurchased;
                oPurchasedItemsSync.PurchasedInApp = modelPurchasedItemsSync.PurchasedInApp;
                oPurchasedItemsSync.Sincronizado = modelPurchasedItemsSync.Sincronizado;
                oPurchasedItemsSync.FechaSync = modelPurchasedItemsSync.FechaSync;

                db.PurchasedItems_Sync.Add(oPurchasedItemsSync);
                db.SaveChanges();

            }
            return Ok("Exito");
        }

        private PurchasedItemsSyncEntities db = new PurchasedItemsSyncEntities();
        //Get Api/MapSync
        public IQueryable<PurchasedItems_Sync> Get()
        {
            return db.PurchasedItems_Sync;
        }

        //GET api/PurchasedItemsSync/5
        [ResponseType(typeof(PurchasedItems_Sync))]
        public IHttpActionResult Get(int id)
        {
            var purchaseditemssync = db.PurchasedItems_Sync.Find(id);
            if (purchaseditemssync == null)
            {
                return NotFound();
            }

            return Ok(purchaseditemssync);
        }

    }
}
