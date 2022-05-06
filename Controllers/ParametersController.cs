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
    public class ParametersController : ApiController
    {
        private ParametersEntities db = new ParametersEntities();

        //Get Api/Parameters
        public IQueryable<Parameters> Get(int year)
        {
            return db.Parameters.Where(x=> x.Year == year);
        }
    }
}
