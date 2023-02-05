using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProje.Models.Entity;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORILER.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER parametre)
        {
            db.TBLKATEGORILER.Add(parametre);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var KategoriSil = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(KategoriSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            return View("KategoriGuncelle", kategori);
        }
        public ActionResult Guncelle(TBLKATEGORILER parametre)
        {
            var musteri = db.TBLKATEGORILER.Find(parametre.KATEGORIID);
            musteri.KATEGORIAD = parametre.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}