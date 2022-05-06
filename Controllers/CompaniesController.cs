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
    public class CompaniesController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private CompaniesEntities db = new CompaniesEntities();
        //Get Api/Companies

        public IQueryable<Companies> Get()
        {
            return db.Companies;
        }

        //lo de abajo me devuelve todos los gastos del banco deseado y del dia especifico
        public HttpResponseMessage GetS(int companyId)
        {
            using (Models.CompaniesEntities db = new Models.CompaniesEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Companies.Where(x => x.CompanyId == companyId).ToList());
            }
        }


        // PUT api/Companies/5
        [ResponseType(typeof(void))]        
        public IHttpActionResult Put(int id, Companies companies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companies.CompanyId)
            {
                return BadRequest();
            }


            db.Entry(companies).State = System.Data.Entity.EntityState.Modified;

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
            return db.Companies.Count(e => e.CompanyId == id) > 0;
        }
    }
}
