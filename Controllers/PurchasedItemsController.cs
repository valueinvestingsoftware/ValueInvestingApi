using BuySell.Models;
using BuySell.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class PurchasedItemsController : ApiController
    {
        //lo de abajo me devuelve el total de compra del item deseado y compras luego de la fecha dada
        public HttpResponseMessage Get(int itemId, DateTime purchaseDate)
        {

            using (Models.PurchasedItemsEntities db = new Models.PurchasedItemsEntities())
            {
             
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                   return Request.CreateResponse(HttpStatusCode.OK, db.PurchasedItems.GroupBy(x=>x.ItemId == itemId & x.PurchaseDate == purchaseDate).Select(y => new PurchasedItemsViewModel
                   
                    {             
                   id = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Count(),
                   ItemId = (int?)db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.ItemId),
                   SupplierId = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.SupplierId),
                   PurchaseQuantity = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Sum(x => x.PurchaseQuantity),
                   PurchasePrice = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Sum(x => x.PurchasePrice),
                   PurchaseDate = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.PurchaseDate),
                   MPurchased = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.MPurchased),
                   MonthNumber = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.MonthNumber),
                   YPurchased = db.PurchasedItems.Where(x => x.ItemId == itemId & x.PurchaseDate >= purchaseDate).Min(x => x.YPurchased),
                   }).ToList());
                    }            
            }
        }

        //lo de abajo me devuelve el total que se ha comprado a un proveedor dado luego de una fecha dada
        public HttpResponseMessage GetS(int supplierId, DateTime purchaseDate)
        {

            using (Models.PurchasedItemsEntities db = new Models.PurchasedItemsEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.PurchasedItems.GroupBy(x => x.SupplierId == supplierId & x.PurchaseDate == purchaseDate).Select(y => new PurchasedItemsViewModel

                    {
                        id = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Count(),
                        ItemId = (int?)db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.ItemId),
                        SupplierId = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.SupplierId),
                        PurchaseQuantity = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Sum(x => x.PurchaseQuantity),
                        PurchasePrice = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Sum(x => x.PurchasePrice),
                        PurchaseDate = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.PurchaseDate),
                        MPurchased = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.MPurchased),
                        MonthNumber = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.MonthNumber),
                        YPurchased = db.PurchasedItems.Where(x => x.SupplierId == supplierId & x.PurchaseDate >= purchaseDate).Min(x => x.YPurchased),                   
                }).ToList());
                }
            }
        }
    }
}
