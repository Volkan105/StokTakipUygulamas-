using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;

namespace StokTakipMVC.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        public ActionResult Index(string p)
        {
            //var urn = db.TblUrunler.Where(x => x.Durum == true).ToList();
            var urunler = db.TblUrunler.Where(x => x.Durum == true);
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.Ad.Contains(p) && x.Durum == true);
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TblUrunler u)
        {
            var ktgr = db.TblKategori.Where(x => x.Id == u.TblKategori.Id).FirstOrDefault();
            u.TblKategori = ktgr;
            db.TblUrunler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.TblKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Ad,
                                             Value = x.Id.ToString()
                                         }).ToList();
            var ktgr = db.TblUrunler.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", ktgr);
        }

        public ActionResult UrunGuncelle(TblUrunler p)
        {
            var urun = db.TblUrunler.Find(p.Id);
            urun.Ad = p.Ad;
            urun.AlisFiyat = p.AlisFiyat;            
            urun.Marka = p.Marka;
            urun.SatisFiyat = p.SatisFiyat;
            urun.Stok = p.Stok;
            var ktg = db.TblKategori.Where(x => x.Id == p.TblKategori.Id).FirstOrDefault();
            urun.Kategori = ktg.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(TblUrunler p1)
        {
            var urunbul = db.TblUrunler.Find(p1.Id);
            urunbul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}