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
    public class SyncAuditController : ApiController
    {

        //Envio un json que tendria que ser deserializado en el cliente
        private SyncAuditEntities db = new SyncAuditEntities();

        public IQueryable<SyncAudit> Get(int id)
        {
            return db.SyncAudit.Where(x => x.id == id);
        }

        // PUT api/SyncAudit/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SyncAudit syncAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != syncAudit.id)
            {
                return BadRequest();
            }


            db.Entry(syncAudit).State = System.Data.Entity.EntityState.Modified;

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
            return db.SyncAudit.Count(e => e.id == id) > 0;
        }

    }
}
