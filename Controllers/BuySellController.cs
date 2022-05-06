using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class BuySellController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private BuySellEntities db = new BuySellEntities();
        //Get Api/BuySell

        public IQueryable<BuySell.Models.BuySell> Get()
        {
            return db.BuySell;
        }
    }
}
