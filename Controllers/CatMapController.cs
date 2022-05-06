using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using BuySell.Models;
using Newtonsoft.Json;

namespace BuySell.Controllers
{

    public class CatMapController : ApiController
    {
              
        //Envio un json que tendria que ser deserializado en el cliente
        private CatMapEntities db = new CatMapEntities();
        //Get Api/Catmap

        public IQueryable<CatMap> Get()
        {
            return db.CatMap.Where(x=> x.VisibleInApps == true);
        }

       
        //lo de abajo me devuelve todos los items del nivel deseado
        public HttpResponseMessage Get(Int16 level)
        {
            using (Models.CatMapEntities db = new Models.CatMapEntities())
            {
                if(level < 6)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.CatMap.Where(x => x.Nivel == level & x.VisibleInApps == true).ToList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, level.ToString() + " is invalid, only 5 item levels are allowed");
                }                
            }
        }

        //lo de abajo me devuelve el item deseado, el que corresponda a la id que quiero
        public IHttpActionResult getOnlyRightLevel(Int32 id)
        {
            using (Models.CatMapEntities db = new Models.CatMapEntities())
            {
                var result = db.CatMap.Where(x => x.id.Equals(id)).ToList();
                return Ok(result);
            }
        }

        // PUT api/CatMap/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, CatMap catmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catmap.id)
            {              

                return BadRequest();
            }

           
            db.Entry(catmap).State = System.Data.Entity.EntityState.Modified;
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
            return db.CatMap.Count(e => e.id == id) > 0;
        }
    }

  
 
}
