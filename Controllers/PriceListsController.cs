using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class PriceListsController : ApiController
    {
        private PriceListsEntities db = new PriceListsEntities();
            //Get Api/PriceLists
            public IQueryable<PriceLists> Get()
        {
            return db.PriceLists;
        }
    }
}
