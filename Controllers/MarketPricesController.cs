using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BuySell.Controllers
{
    public class MarketPricesController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private MarketPricesEntities db = new MarketPricesEntities();
        //Get Api/MarketPrices

        public IQueryable<MarketPrices> Get()
        {
            return db.MarketPrices;
        }

        // PUT api/MarketPrices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, MarketPrices marketPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marketPrice.CompanyID)
            {
                return BadRequest();
            }


            db.Entry(marketPrice).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        private bool itemExists(int id)
        {
            return db.MarketPrices.Count(e => e.CompanyID == id) > 0;
        }
    }
}
