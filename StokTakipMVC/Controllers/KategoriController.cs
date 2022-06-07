using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;

namespace StokTakipMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        public ActionResult Index()
        {
            var kategoriler = db.TblKategori.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var silinecek=db.TblKategori.Find(id);
            db.TblKategori.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(TblKategori k)
        {
            var ktg = db.TblKategori.Find(k.Id);
            ktg.Ad = k.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}