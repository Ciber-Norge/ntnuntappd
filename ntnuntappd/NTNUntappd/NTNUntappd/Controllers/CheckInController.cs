using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTNUntappd.Models;

namespace NTNUntappd.Controllers
{
    public class CheckInController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckIn
        public ActionResult Index()
        {
            return View(db.CheckInModels.ToList());
        }

        // GET: CheckIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInModels checkInModels = db.CheckInModels.Find(id);
            if (checkInModels == null)
            {
                return HttpNotFound();
            }
            return View(checkInModels);
        }

        // GET: CheckIn/Create
        public ActionResult Create()
        {
            var firstOrDefault = db.Users.FirstOrDefault();
            if (firstOrDefault != null) ViewBag.UserId = firstOrDefault.Email;

            var beerModels = db.BeerModels.FirstOrDefault();
            if (beerModels != null) ViewBag.BeerName = beerModels.Name;

            var user = ViewBag.UserId;
            var beer = ViewBag.BeerName;

            var beerMod = new BeerModels()
            {
                Name = beer
            };

            var checkin = new CheckInModels()
            {
                Beer = beerMod,
                UserEmail = user
            };

            if (ModelState.IsValid)
            {
                db.CheckInModels.Add(checkin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        // POST: CheckIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] CheckInModels checkInModels)
        {
            /*if (ModelState.IsValid)
            {
                db.CheckInModels.Add(checkInModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkInModels);*/
            return View();
        }

        // GET: CheckIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInModels checkInModels = db.CheckInModels.Find(id);
            if (checkInModels == null)
            {
                return HttpNotFound();
            }
            return View(checkInModels);
        }

        // POST: CheckIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] CheckInModels checkInModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkInModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkInModels);
        }

        // GET: CheckIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInModels checkInModels = db.CheckInModels.Find(id);
            if (checkInModels == null)
            {
                return HttpNotFound();
            }
            return View(checkInModels);
        }

        // POST: CheckIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckInModels checkInModels = db.CheckInModels.Find(id);
            db.CheckInModels.Remove(checkInModels);
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
