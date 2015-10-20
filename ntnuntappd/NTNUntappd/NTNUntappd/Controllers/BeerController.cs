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
    [Authorize]
    public class BeerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beer
        public ActionResult Index(String query = null)
        {

            if (query == null)
            {
                return View(db.BeerModels.ToList());
            }

            query = query.ToLower();

            IEnumerable<BeerModels> beers = db.BeerModels.Where(b => b.Name.Contains(query) || b.Brewery.Contains(query) || b.Type.Contains(query));

            return View(beers.ToList());
        }

        // GET: Beer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModels beerModels = db.BeerModels.Find(id);
            if (beerModels == null)
            {
                return HttpNotFound();
            }
            return View(beerModels);
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
        public ActionResult Create([Bind(Include = "Id,Name,Type,Brewery")] BeerModels beerModels)
        {
            if (ModelState.IsValid)
            {
                db.BeerModels.Add(beerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beerModels);
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModels beerModels = db.BeerModels.Find(id);
            if (beerModels == null)
            {
                return HttpNotFound();
            }
            return View(beerModels);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Brewery")] BeerModels beerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerModels);
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerModels beerModels = db.BeerModels.Find(id);
            if (beerModels == null)
            {
                return HttpNotFound();
            }
            return View(beerModels);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeerModels beerModels = db.BeerModels.Find(id);
            db.BeerModels.Remove(beerModels);
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
