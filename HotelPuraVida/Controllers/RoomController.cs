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
            RoomModels roomModels = db.RoomModels.Find(id);
            if (roomModels == null)
            {
                return HttpNotFound();
            }
            return View(roomModels);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name");
            return View();
        }

        // POST: Room/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,RoomNumber,RoomType,AvailableDays,MaxPeople,HotelID,CostPerNight,AvailableStatus")] RoomModels roomModels)
        {
            if (ModelState.IsValid)
            {
                db.RoomModels.Add(roomModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModels.HotelID);
            return View(roomModels);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModels roomModels = db.RoomModels.Find(id);
            if (roomModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModels.HotelID);
            return View(roomModels);
        }

        // POST: Room/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,RoomNumber,RoomType,AvailableDays,MaxPeople,HotelID,CostPerNight,AvailableStatus")] RoomModels roomModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.HotelModels, "HotelID", "Name", roomModels.HotelID);
            return View(roomModels);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModels roomModels = db.RoomModels.Find(id);
            if (roomModels == null)
            {
                return HttpNotFound();
            }
            return View(roomModels);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomModels roomModels = db.RoomModels.Find(id);
            db.RoomModels.Remove(roomModels);
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
