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
    public class CarModelsController : ApiController
    {
       //Envio un json que tendria que ser deserializado en el cliente
        private CarModelsEntities db = new CarModelsEntities();
        //Get Api/BankInformation

        public IQueryable<CarModels> Get()
        {
            return db.CarModels;
        }

        // PUT api/CarModels/1
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, CarModels carModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carModels.Id)
            {
                return BadRequest();
            }

            
            db.Entry(carModels).State = System.Data.Entity.EntityState.Modified;

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
            return db.CarModels.Count(e => e.Id == id) > 0;
        }
    }
}

