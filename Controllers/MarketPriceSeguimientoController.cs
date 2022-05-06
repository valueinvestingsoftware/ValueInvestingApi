using BuySell.Models;
using BuySell.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuySell.Controllers
{
    public class MarketPriceSeguimientoController : ApiController
    {

        //Envio un json que tendria que ser deserializado en el cliente
        private MarketPriceSeguimientoEntities db = new MarketPriceSeguimientoEntities();
        //Get Api/MarketPrices

        public IQueryable<MarketPriceSeguimiento> Get()
        {
            DateTime haceTresMeses = DateTime.Now.AddMonths(-3);
            return db.MarketPriceSeguimiento.Where(e => e.RecordedDateAndTime >= haceTresMeses);
        }

        // DELETE api/DeleteMarketPriceSeguimiento/5
        [HttpDelete]
        public HttpResponseMessage DeleteMarketPriceSeguimiento(DateTime dia, int companyId)
        {
            try
            {
                using (MarketPriceSeguimientoEntities marketPriceSeguimientoEntities = new MarketPriceSeguimientoEntities())
                {

                    var entitymarketpriceseguimiento = marketPriceSeguimientoEntities.MarketPriceSeguimiento.Where(e => e.Day == dia & e.CompanyId == companyId);
                    if (entitymarketpriceseguimiento == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No market price exists for this day!");
                    }
                    else
                    {
                        marketPriceSeguimientoEntities.MarketPriceSeguimiento.RemoveRange(entitymarketpriceseguimiento);
                        marketPriceSeguimientoEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.MarketPriceSeguimientoViewModel modelMarketPriceSeguimiento)
        {
            using (MarketPriceSeguimientoEntities db = new MarketPriceSeguimientoEntities())
            {
                var oMarketPriceSeguimiento = new Models.MarketPriceSeguimiento();
                oMarketPriceSeguimiento.CompanyId = modelMarketPriceSeguimiento.CompanyId;
                oMarketPriceSeguimiento.Day = modelMarketPriceSeguimiento.Day;
                oMarketPriceSeguimiento.MarketPrice = modelMarketPriceSeguimiento.MarketPrice;
                oMarketPriceSeguimiento.RecordedDateAndTime = modelMarketPriceSeguimiento.RecordedDateAndTime;
                oMarketPriceSeguimiento.FechaSync = modelMarketPriceSeguimiento.FechaSync;

                db.MarketPriceSeguimiento.Add(oMarketPriceSeguimiento);
                db.SaveChanges();

            }
            return Ok("Exito");
        }

    }
}
