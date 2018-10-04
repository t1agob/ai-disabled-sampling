using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AI_NO_SAMPLING.Controllers
{
    public class HomeController : Controller
    {
        private static TelemetryClient telemetry = new TelemetryClient();

        public ActionResult Index()
        {
            telemetry.TrackEvent("Moved to Index Page");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            telemetry.TrackEvent("Moved to About Page");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            telemetry.TrackEvent("Moved to Contact Page");

            return View();
        }
    }
}