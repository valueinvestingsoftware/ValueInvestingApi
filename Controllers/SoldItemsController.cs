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
    public class SoldItemsController : ApiController
    {
        //lo de abajo me devuelve el total de compra del item deseado y compras luego de la fecha dada
        public HttpResponseMessage Get(int itemId, DateTime soldDate)
        {

            using (Models.SoldItemsEntities db = new Models.SoldItemsEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).GroupBy(x => x.itemid).Select(y => new SoldItemsViewModel

                    {
                        id = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Count(),
                        itemid = (int?)db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Min(x => x.itemid),
                        ClientId = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Min(x => x.ClientId),
                        SaleQuantity = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Sum(x => x.SaleQuantity),
                        SalePrice = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Sum(x => x.SalePrice),
                        SaleDate = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Min(x => x.SaleDate),
                        Profit = db.SoldItems.Where(x => x.itemid == itemId & x.SaleDate >= soldDate).Sum(x => x.Profit),                       
                    }).ToList());
                }
            }
        }

        //lo de abajo me devuelve el total que se ha comprado a un proveedor dado luego de una fecha dada
        public HttpResponseMessage GetS(int supplierId, DateTime soldDate)
        {

            using (Models.SoldItemsEntities db = new Models.SoldItemsEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).GroupBy(x => x.itemid).Select(y => new SoldItemsViewModel

                    {
                        id = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Count(),
                        itemid = (int?)db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.itemid),
                        ClientId = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.ClientId),
                        SaleQuantity = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Sum(x => x.SaleQuantity),
                        SalePrice = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Sum(x => x.SalePrice),
                        SaleDate = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.SaleDate),
                        MSold = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.MSold),
                        MonthNumber = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.MonthNumber),
                        YSold = db.SoldItems.Where(x => x.ClientId == supplierId & x.SaleDate >= soldDate).Min(x => x.YSold),
                    }).ToList());
                }
            }
        }
    }
}
