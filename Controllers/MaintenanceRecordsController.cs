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
    public class MaintenanceRecordsController : ApiController
    {
        //Envio un json que tendria que ser deserializado en el cliente
        private MaintenanceRecordsEntities db = new MaintenanceRecordsEntities();
        //Get Api/MaintenanceRecords

        public IQueryable<MaintenanceRecords> Get()
        {
            return db.MaintenanceRecords;
        }

        

        public IQueryable<MaintenanceRecords> GetCreatedInApp(int createdInApp)
        {
            return db.MaintenanceRecords.Where(x => x.CreatedInApp == true);
        }

        //lo de abajo me devuelve todos los gastos del banco deseado y del dia especifico
        public HttpResponseMessage GetS(Boolean fulfilled, int endKm, int modelId)
        {
            using (Models.MaintenanceRecordsEntities db = new Models.MaintenanceRecordsEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.MaintenanceRecords.Where(x => x.Fulfilled == fulfilled & x.endKm == endKm & x.ModelId == modelId).ToList());
            }
        }


        public HttpResponseMessage GetMax(String max)
        {
            DateTime dTime = DateTime.Now;
            using (Models.MaintenanceRecordsEntities db = new Models.MaintenanceRecordsEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.MaintenanceRecords.Where(x => x.Id == x.Id).OrderByDescending(x => x.Id).GroupBy(x => x.Deleted).Select(y => new MaintenanceRecordsViewModel
                   
                    {
                        Id = db.MaintenanceRecords.Max(x=> x.Id),   //db.SelfLoans.Where(x=> x.Estado == "Not payed").Max(x=> x.YourCurrentDebt),
                        MaintenanceName = "hola",
                        Comment = "hola",
                        ModelId = 0,
                        startKm = 0,
                        endKm = 0,
                        NextAfter = 0,
                        RecordDate = dTime,
                        LastEditDate = dTime,
                        Fulfilled = false,
                        CreatedInApp = false,
                        Deleted = false

                    }).ToList());
                }
            }
        }

        // PUT api/MaintenanceRecords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, MaintenanceRecords maintenanceRecords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenanceRecords.Id)
            {
                return BadRequest();
            }


            db.Entry(maintenanceRecords).State = System.Data.Entity.EntityState.Modified;

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
            return db.MaintenanceRecords.Count(e => e.Id == id) > 0;
        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.MaintenanceRecordsViewModel modelMaintenanceRecords)
        {
            using (MaintenanceRecordsEntities db = new MaintenanceRecordsEntities())
            {
                var oMaintenanceRecords = new Models.MaintenanceRecords();
                oMaintenanceRecords.Id = modelMaintenanceRecords.Id;
                oMaintenanceRecords.MaintenanceName = modelMaintenanceRecords.MaintenanceName;
                oMaintenanceRecords.Comment = modelMaintenanceRecords.Comment;
                oMaintenanceRecords.ModelId = modelMaintenanceRecords.ModelId;
                oMaintenanceRecords.startKm = modelMaintenanceRecords.startKm;
                oMaintenanceRecords.endKm = modelMaintenanceRecords.endKm;
                oMaintenanceRecords.NextAfter = modelMaintenanceRecords.NextAfter;
                oMaintenanceRecords.RecordDate = modelMaintenanceRecords.RecordDate;
                oMaintenanceRecords.LastEditDate = modelMaintenanceRecords.LastEditDate;
                oMaintenanceRecords.Fulfilled = modelMaintenanceRecords.Fulfilled;
                oMaintenanceRecords.CreatedInApp = modelMaintenanceRecords.CreatedInApp;
                oMaintenanceRecords.Deleted = modelMaintenanceRecords.Deleted;
                oMaintenanceRecords.FechaSync = modelMaintenanceRecords.FechaSync;

                db.MaintenanceRecords.Add(oMaintenanceRecords);
                db.SaveChanges();

            }
            return Ok("Exito");
        }

        // DELETE api/MaintenanceRecords/5

        //public HttpResponseMessage DeleteMaintenanceRecords(int id)
        //{
        //    try
        //    {
        //        using (MaintenanceRecordsEntities maintenanceRecordsEntities = new MaintenanceRecordsEntities())
        //        {
        //            var entitymaintenance = maintenanceRecordsEntities.MaintenanceRecords.FirstOrDefault(e=> e.Id > 0);
        //            if (entitymaintenance == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No maintenance Exists!");
        //            }
        //            else
        //            {
        //                maintenanceRecordsEntities.MaintenanceRecords.Remove(entitymaintenance);
        //                maintenanceRecordsEntities.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        // DELETE api/MaintenanceRecords/5

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (MaintenanceRecordsEntities maintenanceRecordsEntities = new MaintenanceRecordsEntities())
                {
                   
                    var entitymaintenance = maintenanceRecordsEntities.MaintenanceRecords.Where(e=> e.Id == id);
                    if (entitymaintenance == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No maintenance Exists!");
                    }
                    else
                    {
                        maintenanceRecordsEntities.MaintenanceRecords.RemoveRange(entitymaintenance);
                        maintenanceRecordsEntities.SaveChanges();
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
