using HotelPuraVida.Models;
using HotelPuraVida.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelPuraVida.Controllers
{
    public class OrderReservationsController : Controller
    {
        HotelPuraVidaContext db = new HotelPuraVidaContext();
        ApplicationDbContext bd = new ApplicationDbContext();
        // GET: OrderReservations
        public ActionResult NewReservation()
        {
           
            var OrderReservationView = new OrderReservationViewModels();
            OrderReservationView.UserViewModels = new UserViewModels();
            OrderReservationView.Room = new List<RoomOrderModels>();


            //Para generar un DropDownList
  //SEGURO QUE NO SIRVE POR QUE NO JALA LOS DATOS DEL USUARIO
            //var list = db.RoomModels.ToList();
            //list.Add(new RoomOrderModels { RoomID = 0, RoomType = "[Seleccione]" });
            //list.OrderBy(r => r.RoomType).ToList();
            //ViewBag.RoomID = new SelectList(list, "RoomID", "RoomType");


            return View(OrderReservationView);
        }
        [HttpPost]
        public ActionResult NewReservation(OrderReservationViewModels OrderReservationView)
        {


            return View(OrderReservationView);
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