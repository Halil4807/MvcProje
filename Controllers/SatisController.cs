using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProje.Models.Entity;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class SatisController : Controller
    {

        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR parametre)
        {
            db.TBLSATISLAR.Add(parametre);
            db.SaveChanges();
            return View("Index");
        }
    }
}