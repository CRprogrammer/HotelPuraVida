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
      
        // GET: OrderReservations
        public ActionResult NewReservation()
        {
           
            var OrderReservationView = new OrderReservationViewModels();
            OrderReservationView.UserViewModels = new UserViewModels();
            OrderReservationView.RoomOrder = new List<RoomOrderModels>();

            Session["OrderReservationView"] = OrderReservationView;


            return View(OrderReservationView);
        }
        [HttpPost]
        public ActionResult NewReservation([Bind(Include = "Name")] OrderReservationViewModels OrderReservationView)
        { ///Arreglar error del Nombre del Usuario al que sale la reservacion
          ///Video 20
            OrderReservationView = Session["OrderReservationView"] as OrderReservationViewModels;
            var UserID = Request["UserID"];          

            ////Esto es por si utiliza un textbox  validar que no este vacio
            //if (ModelState.IsValid)
            //{
            //     //esto da error porq la tabla aun no existe existe, 
            //    db.OrderReservationViewModels.Add(OrderReservationView);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

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
               
                return View(RoomOrder);
            }

            var room = db.RoomModels.Find(RoomID);
            if (room == null)
            {

                var list = db.RoomModels.ToList();
                list.OrderBy(r => r.RoomType).ToList();
                list.Add(new RoomOrderModels { RoomID = 0, RoomType = "[Seleccione]" });
                ViewBag.RoomID = new SelectList(list, "RoomID", "RoomType");

                ViewBag.Error = "La Habitacion que selecciono no esta disponible.";
                
                return View(RoomOrder);
            }
            RoomOrder = OrderReservationView.RoomOrder.Find(r => r.RoomID == RoomID);
            if (RoomOrder == null)
            {
                RoomOrder = new RoomOrderModels
                {
                    HotelID = RoomOrder.HotelID,
                    RoomID = RoomOrder.RoomID,
                    RoomNumber = RoomOrder.RoomNumber,
                    RoomType = RoomOrder.RoomType,
                    People = float.Parse(Request["People"]),
                    CostPerNight = RoomOrder.CostPerNight,


                };
                OrderReservationView.RoomOrder.Add(RoomOrder);
            }
            else
            {
                RoomOrder.People += float.Parse(Request["People"]);
            }

           

            return View("NewReservation", RoomOrder);
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