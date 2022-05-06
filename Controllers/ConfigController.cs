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
    public class ConfigController : ApiController
    {
        private ConfigEntities db = new ConfigEntities();

        //Get Api/Config
        public IQueryable<Config> Get()
        {
            return db.Config;
        }
    }
}
