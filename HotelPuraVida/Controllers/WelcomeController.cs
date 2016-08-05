using HotelPuraVida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelPuraVida.Controllers
{
    [Authorize]
    public class WelcomeController : Controller
    {
        private HotelPuraVidaContext db = new HotelPuraVidaContext();
        // GET: Welcome
        public ActionResult Index()
        {
            return View(db.HotelModels.ToList());
        }

        // GET: Welcome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelModels hotelModels = db.HotelModels.Find(id);
            if (hotelModels == null)
            {
                return HttpNotFound();
            }
            return View(hotelModels);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
}
