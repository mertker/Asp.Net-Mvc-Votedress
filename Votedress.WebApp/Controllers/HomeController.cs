using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Votedress.BusinessLayer;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;
using Votedress.WebApp.App_Start;


namespace Votedress.WebApp.Controllers
{
    [LoginFilter]
    [BireyselUserFilter]
    [LoglamaFilter]
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}