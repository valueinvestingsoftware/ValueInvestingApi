using BuySell.Models;
using BuySell.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;

namespace BuySell.Controllers
{   

    public class SpencesController : ApiController
    {

        private SpencesEntities db = new SpencesEntities();

        //Get Api/Prices

        public IQueryable<Spences> Get()
        {
            return db.Spences.Where(x => x.CreatedInApp == true);
        }

        public IQueryable<Spences> Get(int year)
        {
            return db.Spences.Where(x => x.Spence > 0 & x.YSpences == year);
        }

        //lo de abajo me devuelve el total de venta del item deseado y ventas luego de la fecha dada
        public HttpResponseMessage Get(Byte spenceId, Int16 year, Byte monthNumber)
        {

            using (Models.SpencesEntities db = new Models.SpencesEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences == year & x.MonthNumber == monthNumber).GroupBy(x => x.MonthNumber & x.YSpences).Select(y => new SpencesViewModel

                    {
                        id = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences == year & x.MonthNumber == monthNumber).Count(),
                        SpenceId = spenceId,
                        DSpences = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences >= year & x.MonthNumber == monthNumber).Min(x => x.DSpences),
                        dia = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences >= year & x.MonthNumber == monthNumber).Min(x => x.dia),
                        DiaNumber = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences >= year & x.MonthNumber == monthNumber).Min(x => x.DiaNumber),
                        DiaSpences = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences >= year & x.MonthNumber == monthNumber).Min(x => x.DiaSpences),
                        MSpences = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences >= year & x.MonthNumber == monthNumber).Max(x => x.MSpences),
                        MonthNumber = monthNumber,
                        YSpences = year,
                        Spence = db.Spences.Where(x => x.SpenceId == spenceId & x.YSpences == year & x.MonthNumber == monthNumber).Sum(x => x.Spence),    
                        CreatedInApp = false
                    }).ToList());                    
                }
            }
        }


        //lo de abajo me devuelve todos los items del nivel deseado
        public HttpResponseMessage Get(DateTime spenceDate)
        {
            using (Models.SpencesEntities db = new Models.SpencesEntities())
            {                
                    return Request.CreateResponse(HttpStatusCode.OK, db.Spences.Where(x => x.DSpences == spenceDate).ToList());               
            }
        }

        //lo de abajo me devuelve todos los items del nivel deseado
        public HttpResponseMessage GetS(DateTime spenceDate, int spenceId)
        {
            using (Models.SpencesEntities db = new Models.SpencesEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Spences.Where(x => x.DSpences == spenceDate & x.SpenceId == spenceId).ToList());
            }
        }


        // PUT api/Spences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Spences spences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spences.id)
            {
                return BadRequest();
            }


            db.Entry(spences).State = System.Data.Entity.EntityState.Modified;
           
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
            return db.Spences.Count(e => e.id == id) > 0;
        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.SpencesViewModel modelSpences)
        {
            using (SpencesEntities db = new SpencesEntities())
            {
                var oSpences = new Models.Spences();
                //oSpences.id = modelSpences.id;
                oSpences.SpenceId = modelSpences.SpenceId;
                oSpences.Spence = modelSpences.Spence;
                oSpences.DSpences = modelSpences.DSpences;
                oSpences.dia = modelSpences.dia;
                oSpences.DiaNumber = modelSpences.DiaNumber;
                oSpences.DiaSpences = modelSpences.DiaSpences;
                oSpences.MSpences = modelSpences.MSpences;
                oSpences.MonthNumber = modelSpences.MonthNumber;
                oSpences.YSpences = modelSpences.YSpences;
                oSpences.CreatedInApp = modelSpences.CreatedInApp;
                oSpences.SelfLoans_AfterSync = modelSpences.SelfLoans_AfterSync;
                oSpences.FechaSync = modelSpences.FechaSync;
                oSpences.DebitUniqueIdentifier = modelSpences.DebitUniqueIdentifier;
             
                db.Spences.Add(oSpences);
                db.SaveChanges();

            }
            return Ok("Exito");
        }

        // DELETE api/DeleteSpences/5

        public HttpResponseMessage DeleteSpences(int spenceId, DateTime day)
        {
            try
            {
                using (SpencesEntities spenceEntities = new SpencesEntities())
                {
                    var entitySpences = spenceEntities.Spences.FirstOrDefault(e => e.SpenceId == spenceId & e.DSpences == day);
                    if (entitySpences == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Expense does not exist!");
                    }
                    else
                    {
                        spenceEntities.Spences.Remove(entitySpences);
                        spenceEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }           
            
        }
    }   

}





