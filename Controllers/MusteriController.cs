using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProje.Models.Entity;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string ara)
        {
            var sonuc = from i in db.TBLMUSTERILER select i;
            if (!string.IsNullOrEmpty(ara))
            {
                sonuc = sonuc.Where(m=>m.MUSTERIAD.Contains(ara));
            }
            return View(sonuc.ToList());
            //var musteri = db.TBLMUSTERILER.ToList();
            //return View(musteri);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER parametre)
        {

            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(parametre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var MusteriSil = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(MusteriSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGuncelle", musteri);
        }
        public ActionResult Guncelle(TBLMUSTERILER parametre)
        {
            var musteri = db.TBLMUSTERILER.Find(parametre.MUSTERIID);
            musteri.MUSTERIAD = parametre.MUSTERIAD;
            musteri.MUSTERISOYAD = parametre.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}