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
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var kategoriler = db.TBLKATEGORILER.ToList();
            var kategoriler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa,4);
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
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(parametre);
            db.SaveChanges();
            return RedirectToAction("Index");
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