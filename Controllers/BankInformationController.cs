using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class BankInformationController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private BankInformationEntities db = new BankInformationEntities();
        //Get Api/BankInformation

        public IQueryable<BankInformation> Get()
        {
            return db.BankInformation;
        }
    }
}
