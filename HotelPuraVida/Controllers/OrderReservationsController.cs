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

            Session["OrderReservationView"] = OrderReservationView;
            //Para generar un DropDownList
  //SEGURO QUE NO SIRVE POR QUE NO JALA LOS DATOS DEL USUARIO
            //var list = db.RoomModels.ToList();
            //list.OrderBy(r => r.RoomType).ToList();
            //list.Add(new RoomOrderModels { RoomID = 0, RoomType = "[Seleccione]" });
            //ViewBag.RoomID = new SelectList(list, "RoomID", "RoomType");


            return View(OrderReservationView);
        }
        [HttpPost]
        public ActionResult NewReservation(OrderReservationViewModels OrderReservationView)
        {


            return View(OrderReservationView);
        }

        public ActionResult AddReservation()
        {
            var list = db.RoomModels.ToList();
            list.OrderBy(r => r.RoomType).ToList();
            list.Add(new RoomOrderModels { RoomID = 0, RoomType = "[Seleccione]" });
            ViewBag.RoomID = new SelectList(list, "RoomID", "RoomType");
            return View();
        }
        [HttpPost]
        public ActionResult AddReservation(RoomOrderModels RoomOrder)
        {
            var OrderReservationView = Session["OrderReservationView"] as OrderReservationViewModels;

            var RoomID =int.Parse( Request["RoomID"]);
            if(RoomID==0){
                var list = db.RoomModels.ToList();
                list.OrderBy(r => r.RoomType).ToList();
                list.Add(new RoomOrderModels { RoomID = 0, RoomType = "[Seleccione]" });
                ViewBag.RoomID = new SelectList(list, "RoomID", "RoomType");

                ViewBag.Error = "Debe Seleccionar un tipo de Habitación.";
                //aqui quede
                return View(RoomOrder);
            }

           
            return View(RoomOrder);
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