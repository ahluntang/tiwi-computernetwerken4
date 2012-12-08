using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BadmintonWebClient.BadmintonServiceReference;

namespace BadmintonWebClient.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            IBadminton client = (IBadminton) Request.RequestContext.HttpContext.Application["service"];
            SportClubType[] sportclubs = client.GetAlleSportClubs();
            return View(sportclubs);
        }

        public ActionResult Leden(int id)
        {
            IBadminton client = (IBadminton)Request.RequestContext.HttpContext.Application["service"];
            SportClubType club = new SportClubType();
            club.ID = id;
            LidType[] leden = client.GetLeden(club);
            return View(leden);
        }
    }
}
