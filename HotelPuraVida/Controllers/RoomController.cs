using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelPuraVida.Models;

namespace HotelPuraVida.Controllers
{
    //[Authorize]
    public class RoomController : Controller
    {
        private HotelPuraVidaContext db = new HotelPuraVidaContext();

        // GET: Room
        public ActionResult Index()
        {
            var roomModels = db.RoomModels.Include(r => r.HotelModels);
            return View(roomModels.ToList());
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.RoomModels.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name");
            return View();
        }

        // POST: Room/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,RoomNumber,RoomType,AvailableDays,MaxPeople,HotelID,CostPerNight")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                db.RoomModels.Add(roomModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModel.HotelID);
            return View(roomModel);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.RoomModels.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModel.HotelID);
            return View(roomModel);
        }

        // POST: Room/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,RoomNumber,RoomType,AvailableDays,MaxPeople,HotelID,CostPerNight")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModel.HotelID);
            return View(roomModel);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.RoomModels.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomModel roomModel = db.RoomModels.Find(id);
            db.RoomModels.Remove(roomModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
