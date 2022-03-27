using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSPDFinalProject.Data.EF;

namespace FSPDFinalProject.Controllers
{

    public class ReservationController : Controller
    {
        private ReservationSystemEntities db = new ReservationSystemEntities();

        // GET: Reservation
        public ActionResult Index()
        {
            var reservations = db.Locations.Include(e => e.Reservations);
            return View(reservations.ToList());
        }

        public ActionResult Full()
        {
            return View();
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets, "OwnerAssetId", "AssetName");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,OwnerAssetId,LocationId,ReservationDate")] Reservation reservation)
        {
            var resId = reservation.LocationId;
            if (ModelState.IsValid)
            {
                var result = (from a in db.Locations
                              where a.LocationId == reservation.LocationId
                              select new { a.ReservationLimit, a.Reservations });
                if (result.First().Reservations.Count() >= result.First().ReservationLimit)
                {
                    if (User.IsInRole("Admin"))
                    {
                        db.Reservations.Add(reservation);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Full");
                    }
                }
                else
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets, "OwnerAssetId", "AssetName", reservation.OwnerAssetId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", reservation.LocationId);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Remove()
        {
            var reservations = db.Reservations;
            return View(reservations.ToList());
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
