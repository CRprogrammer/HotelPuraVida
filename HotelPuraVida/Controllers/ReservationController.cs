﻿using System;
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
    public class ReservationController : Controller
    {
        private HotelPuraVidaContext db = new HotelPuraVidaContext();

        [Authorize(Roles = "View")]
        // GET: Reservation
        public ActionResult Index()
        {
            return View(db.ReservationModels.ToList());
        }

        [Authorize(Roles = "View")]
        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.ReservationModels.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        [Authorize(Roles = "Create")]
        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,Username,People,Date,HotelID,RoomID,LoginID")] ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                db.ReservationModels.Add(reservationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservationModel);
        }

        [Authorize(Roles = "Edit")]
        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.ReservationModels.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: Reservation/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,Username,People,Date,HotelID,RoomID,LoginID")] ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationModel);
        }

        [Authorize(Roles = "Delete")]
        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.ReservationModels.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationModel reservationModel = db.ReservationModels.Find(id);
            db.ReservationModels.Remove(reservationModel);
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
