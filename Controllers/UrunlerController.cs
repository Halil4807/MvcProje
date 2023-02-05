using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProje.Models.Entity;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProje.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var urunler = db.TBLURUNLER.ToList();
            var urunler = db.TBLURUNLER.ToList().ToPagedList(sayfa, 6);
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
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.ktg = degerler;
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGuncelle", urun);
        }

        public ActionResult Guncelle(TBLURUNLER parametre)
        {
            var urun = db.TBLURUNLER.Find(parametre.URUNID);
            urun.URUNAD = parametre.URUNAD;
            urun.MARKA = parametre.MARKA;
            //urun.URUNKATEGORI = parametre.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == parametre.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            urun.FIYAT = parametre.FIYAT;
            urun.STOK = parametre.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}