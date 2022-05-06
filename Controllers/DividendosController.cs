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
    public class DividendosController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private DividendosEntities db = new DividendosEntities();
        //Get Api/Dividendos

        public IQueryable<Dividendos> Get()
        {
            return db.Dividendos;
        }

        //lo de abajo me devuelve todos los gastos del banco deseado y del dia especifico
        public HttpResponseMessage GetS(int companyId, int year)
        {
            using (Models.DividendosEntities db = new Models.DividendosEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Dividendos.Where(x => x.CompanyID == companyId & x.Year == year).ToList());
            }
        }

        // PUT api/Dividendos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Dividendos dividendos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dividendos.id)
            {
                return BadRequest();
            }


            db.Entry(dividendos).State = System.Data.Entity.EntityState.Modified;

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
            return db.Dividendos.Count(e => e.id == id) > 0;
        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.DividendosViewModel modelDividendos)
        {
            using (DividendosEntities db = new DividendosEntities())
            {
                var oDividendos = new Models.Dividendos();
                //oDividendos.id = modelMaintenanceRecords.id;
                oDividendos.CompanyID = modelDividendos.CompanyID;
                oDividendos.Year = modelDividendos.Year;
                oDividendos.DividendosEfectivo = modelDividendos.DividendosEfectivo;
                oDividendos.DividendosAccion = modelDividendos.DividendosAccion;
                oDividendos.AccionesPrecedentes = modelDividendos.AccionesPrecedentes;
                oDividendos.AccionesPorAccion = modelDividendos.AccionesPorAccion;
                oDividendos.EfectivoPorAccion = modelDividendos.EfectivoPorAccion;
                oDividendos.Distribute = modelDividendos.Distribute;
                oDividendos.Graph = modelDividendos.Graph;
                oDividendos.AvSalePrice = modelDividendos.AvSalePrice;                

                db.Dividendos.Add(oDividendos);
                db.SaveChanges();

            }
            return Ok("Exito");
        }
    }
   
}
