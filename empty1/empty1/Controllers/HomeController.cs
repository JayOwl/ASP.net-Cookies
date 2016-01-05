using empty1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace empty1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionHelper sessionHlp = new SessionHelper();
            if (Request.Cookies["ASP.NET_SessionId"] == null)//Correction
                sessionHlp.Intialize();
            else
                sessionHlp.Intialize();

            ViewBag.SessionStart = sessionHlp.Start.ToString();
            ViewBag.SessionEnd = sessionHlp.End.ToString();
            ViewBag.SessionID = sessionHlp.SessionID;
            return View();
        }
        [HttpPost]
        public ActionResult ClearSession() {
            SessionHelper sessionHlp = new SessionHelper();
            sessionHlp.Clear();
            return RedirectToAction("Index");
        }

    }
}