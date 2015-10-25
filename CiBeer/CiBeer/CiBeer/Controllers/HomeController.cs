using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using CiBeer.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebGrease.Css.Extensions;

namespace CiBeer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            
            var entries = db.CheckInModels.Include(models => models.Beer).Include(models => models.User).ToList();
            var grouped = entries.GroupBy(models => models.Beer).OrderBy(groups => groups.Count());

            var dict = grouped.ToDictionary(p => p.Key);
            var groupedCount = dict.ToDictionary(v => v.Key, v => v.Value.Count());

            return View(groupedCount);
        }
    }
}