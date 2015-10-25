using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiBeer.Models;
using Microsoft.AspNet.Identity;


namespace CiBeer.Controllers
{
    [Authorize] //User has to be logged in
    public class CheckInController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckIn
        public ActionResult Index()
        {
            return View(db.CheckInModels.Include(x => x.Beer).Include(y => y.User).ToList().Where(models => models.UserId == User.Identity.GetUserId()));
        }

        // GET: CheckIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInModel checkInModel = db.CheckInModels.Find(id);
            if (checkInModel == null)
            {
                return HttpNotFound();
            }
            return View(checkInModel);
        }

        // CheckIn/Create
        public ActionResult Create(string beerName)
        {
            string userEmail = User.Identity.Name;
            var beerId = db.BeerModels.FirstOrDefault(models => models.Name == beerName).Id;
            var usr = db.Users.FirstOrDefault(u => u.UserName == userEmail);

            var checkin = new CheckInModel()
            {
                BeerId = beerId,
                UserId = usr.Id
            };

            if (ModelState.IsValid)
            {
                db.CheckInModels.Add(checkin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        // GET: CheckIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInModel checkInModels = db.CheckInModels.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,UserId,BeerId")] CheckInModel checkInModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkInModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkInModel);
        }

        // GET: CheckIn/Delete/5
        public ActionResult Delete(int? id)
        {
            CheckInModel checkInModels = db.CheckInModels.Find(id);
            db.CheckInModels.Remove(checkInModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CheckIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckInModel checkInModel = db.CheckInModels.Find(id);
            db.CheckInModels.Remove(checkInModel);
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
