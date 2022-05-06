using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class SpenceCategoryController : ApiController
    {
        private SpenceCategoryEntities db = new SpenceCategoryEntities();
        //Get Api/Prices
        public IQueryable<SpenceCategory> Get()
        {
            return db.SpenceCategory.Where(x => x.Hidden == false);
        }
    }
}
