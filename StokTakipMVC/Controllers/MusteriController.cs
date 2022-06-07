using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StokTakipMVC.Controllers
{
    public class MusteriController : Controller
    {
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        // GET: Musteri
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var musteriliste = db.TblMusteri.ToList();
            var musteriliste = db.TblMusteri.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.Durum = true;
            db.TblMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(TblMusteri p)
        {
            var musteribul = db.TblMusteri.Find(p.Id);
            musteribul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var gelenmusteri = db.TblMusteri.Find(id);
            return View("MusteriGetir",gelenmusteri);
        }

        public ActionResult MusteriGuncelle(TblMusteri t)
        {
            var mus = db.TblMusteri.Find(t.Id);
            mus.Ad = t.Ad;
            mus.Soyad = t.Soyad;
            mus.Sehir = t.Sehir;
            mus.Bakiye = t.Bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
            
    }
}