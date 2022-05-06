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
    public class BankSummariesController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private BankSummariesEntities db = new BankSummariesEntities();
       
        public IQueryable<BankSummaries> Get()
        {
            return db.BankSummaries;
        }
    }
}
