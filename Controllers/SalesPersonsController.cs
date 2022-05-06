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
    public class SalesPersonsController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private SalesPersonsEntities db = new SalesPersonsEntities();

        public IQueryable<SalesPersons> Get()
        {
            return db.SalesPersons.Where(e => e.Active == true);
        }
    }
}
