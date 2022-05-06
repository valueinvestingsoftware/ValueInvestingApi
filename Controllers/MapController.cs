using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class MapController : ApiController
    {
        private MapEntities db = new MapEntities();
             //Get Api/Map
        public IQueryable<Map> Get()
        {
            return db.Map;
        }
    }
}
