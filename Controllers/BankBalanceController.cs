using BuySell.Models;
using BuySell.Models.ViewModel;
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
    public class BankBalanceController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private BankBalanceEntities db = new BankBalanceEntities();
        //Get Api/BankBalance

        public IQueryable<BankBalance> Get()
        {
            return db.BankBalance.Where(x => x.CreatedInApp == true);
        }

        public IQueryable<BankBalance> Get(int year)
        {
            return db.BankBalance.Where(x=> x.YSpences == year);
        }


        public HttpResponseMessage Get(int bankId, int monthNumber, int year)
        {
            DateTime d = new DateTime(year, monthNumber, 1);

            using (Models.BankBalanceEntities db = new Models.BankBalanceEntities())
            {
              
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.BankBalance.Where(x => x.BankId == bankId & x.RecordDate.Value.Year == year & x.RecordDate.Value.Month == monthNumber).GroupBy(x => x.RecordDate.Value.Month & x.RecordDate.Value.Year & x.BankId).Select(y => new BankBalanceViewModel
                    
                     {
                        Id = db.BankBalance.Where(x => x.BankId == bankId & x.RecordDate.Value.Year == year & x.RecordDate.Value.Month == monthNumber).Count(),
                        BankId = db.BankBalance.Where(x => x.BankId == bankId & x.RecordDate.Value.Year == year & x.RecordDate.Value.Month == monthNumber).Min(x => x.BankId),
                        Operation = "Summary",
                        Value = db.BankBalance.Where(x => x.BankId == bankId & x.RecordDate.Value.Year == year & x.RecordDate.Value.Month == monthNumber).Sum(x => x.Value),
                        Comment = "Summary",                       
                        RecordDate = d,
                        LastEditDale = d,
                        CreatedInApp = false,
                    }).ToList());
                }
            }
        }


        //lo de abajo me devuelve todos los gastos del banco deseado y del dia especifico
        public HttpResponseMessage GetS(DateTime gastosDate, int bancoId, String tipo)
        {
            using (Models.BankBalanceEntities db = new Models.BankBalanceEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.BankBalance.Where(x => x.RecordDate == gastosDate & x.BankId == bancoId & x.Operation == tipo).ToList());
            }
        }

        // PUT api/BankBalance/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, BankBalance bankBalance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankBalance.Id)
            {
                return BadRequest();
            }


            db.Entry(bankBalance).State = System.Data.Entity.EntityState.Modified;

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
            return db.BankBalance.Count(e => e.Id == id) > 0;
        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.BankBalanceViewModel modelBankBalance)
        {
            using (BankBalanceEntities db = new BankBalanceEntities())
            {
                var oBankBalance = new Models.BankBalance();
                //oSpences.id = modelSpences.id;
                oBankBalance.BankId = modelBankBalance.BankId;
                oBankBalance.Operation = modelBankBalance.Operation;
                oBankBalance.Value = modelBankBalance.Value;
                oBankBalance.Comment = modelBankBalance.Comment;
                oBankBalance.RecordDate = modelBankBalance.RecordDate;
                oBankBalance.LastEditDale = modelBankBalance.LastEditDale;
                oBankBalance.CreatedInApp = modelBankBalance.CreatedInApp;
                oBankBalance.MSpences = modelBankBalance.MSpences;
                oBankBalance.MonthNumber = modelBankBalance.MonthNumber;
                oBankBalance.YSpences = modelBankBalance.YSpences;
                oBankBalance.GetDebitNumber_AfterSync = modelBankBalance.GetDebitNumber_AfterSync;
                oBankBalance.FechaSync = modelBankBalance.FechaSync;
                oBankBalance.DebitUniqueIdentifier = modelBankBalance.DebitUniqueIdentifier;

                db.BankBalance.Add(oBankBalance);
                db.SaveChanges();

            }
            return Ok("Exito");
        }


        // DELETE api/BankBalance/5

        public HttpResponseMessage Delete(int BankId, DateTime day, string operation)
        {
            try
            {
                using (BankBalanceEntities bankBalanceEntities = new BankBalanceEntities())
                {

                    var entityBankbalance = bankBalanceEntities.BankBalance.Where(e => e.BankId == BankId & e.RecordDate == day & e.Operation == operation);
                    if (entityBankbalance == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No bank balance Exists!");
                    }
                    else
                    {
                        bankBalanceEntities.BankBalance.RemoveRange(entityBankbalance);
                        bankBalanceEntities.SaveChanges();
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
