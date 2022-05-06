using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class MonthNamesController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private MonthNamesEntities db = new MonthNamesEntities();
        //Get Api/MonthNames

        public IQueryable<MonthNames> Get()
        {
            return db.MonthNames.Where(e => e.LanguageId == 1);
        }

    }
}
