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
    
    public class HotelController : Controller
    {
        private HotelPuraVidaContext db = new HotelPuraVidaContext();

        [Authorize (Roles="View")]
        // GET: Hotel
        public ActionResult Index()
        {
            return View(db.HotelModels.ToList());
        }
         [Authorize(Roles = "View")]
        // GET: Hotel/Details/5
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

         [Authorize(Roles = "Create")]
        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelID,Name,Company,Rating")] HotelModels hotelModels)
        {
            if (ModelState.IsValid)
            {
                db.HotelModels.Add(hotelModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelModels);
        }
         [Authorize(Roles = "Edit")]
        // GET: Hotel/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Hotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelID,Name,Company,Rating")] HotelModels hotelModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelModels);
        }
         [Authorize(Roles = "Delete")]
        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelModels hotelModels = db.HotelModels.Find(id);
            db.HotelModels.Remove(hotelModels);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                throw;
            }
           
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
