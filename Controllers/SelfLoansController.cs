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
    public class SelfLoansController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DateTime dTime = DateTime.Now;
            using (Models.SelfLoansEntities db = new Models.SelfLoansEntities())
            {

                {
                    //return Request.CreateResponse(HttpStatusCode.OK, db.BuySell.Where(x => x.Nivel == level).Select(y => new BuySell.Models.BuySell
                    return Request.CreateResponse(HttpStatusCode.OK, db.SelfLoans.Where(x => x.Estado == "Not payed").OrderByDescending(x => x.LoanId).GroupBy(x => x.Estado).Select(y => new SelfLoansViewModel

                    {
                        LoanId = 0,
                        LoanDescription = "hola",
                        LoanDate = dTime,
                        NumberOfInstallments = 0,
                        Amount = db.SelfLoans.Where(x => x.Estado == "Not payed").Sum(x => x.Amount),
                        AlreadyPayed = db.SelfLoans.Where(x => x.Estado == "Not payed").Sum(x => x.AlreadyPayed),
                        YourCurrentDebt = db.SelfLoans.Where(x=> x.Estado == "Not payed").Sum(x=> x.YourCurrentDebt),
                        EachInstallment = db.SelfLoans.Where(x => x.Estado == "Not payed").Sum(x => x.EachInstallment),
                        Estado = "Not payed",
                        PaidDate = dTime
                    }).ToList());
                }
            }
        }
    }
}
