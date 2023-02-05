using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProje.Models.Entity;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TBLURUNLER.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.ktg = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER parametre)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == parametre.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            parametre.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(parametre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var UrunSil = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(UrunSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGuncelle(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGuncelle", urun);
        }
        public ActionResult Guncelle(TBLURUNLER parametre)
        {
            var urun = db.TBLURUNLER.Find(parametre.URUNID);
            urun.URUNAD = parametre.URUNAD;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}