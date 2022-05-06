using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class PricesController : ApiController
    {
        private PricesEntities db = new PricesEntities();
              //Get Api/Prices
        public IQueryable<Prices> Get()
        {
            return db.Prices;
        }
    }
}
