using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiBeer.Models;

namespace CiBeer.Controllers
{
    public class BeerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beer
        public ActionResult Index()
        {
            return View(db.BeerModels.ToList());
        }

        // GET: Beer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModel beerModel = db.BeerModels.Find(id);
            if (beerModel == null)
            {
                return HttpNotFound();
            }
            return View(beerModel);
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Brewery")] BeerModel beerModel)
        {
            if (ModelState.IsValid)
            {
                db.BeerModels.Add(beerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beerModel);
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModel beerModel = db.BeerModels.Find(id);
            if (beerModel == null)
            {
                return HttpNotFound();
            }
            return View(beerModel);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Brewery")] BeerModel beerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerModel);
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModel beerModel = db.BeerModels.Find(id);
            if (beerModel == null)
            {
                return HttpNotFound();
            }
            return View(beerModel);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeerModel beerModel = db.BeerModels.Find(id);
            db.BeerModels.Remove(beerModel);
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
