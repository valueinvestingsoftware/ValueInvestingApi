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
    public class InvestmentController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private InvestmentEntities db = new InvestmentEntities();
        //Get Api/Investment

        public IQueryable<Investment> Get()
        {
            return db.Investment;
        }

        //lo de abajo me devuelve todos los gastos del banco deseado y del dia especifico
        public HttpResponseMessage GetS(int companyId)
        {
            using (Models.InvestmentEntities db = new Models.InvestmentEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Investment.Where(x => x.CompanyId == companyId).ToList());
            }
        }

        // PUT api/Investment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Investment investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investment.CompanyId)
            {
                return BadRequest();
            }


            db.Entry(investment).State = System.Data.Entity.EntityState.Modified;

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
            return db.Investment.Count(e => e.CompanyId == id) > 0;
        }
      
    }
}
