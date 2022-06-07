using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;

namespace StokTakipMVC.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        public ActionResult Index()
        {
            var satis=db.TblSatislar.ToList();
            return View(satis);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> urn = (from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.drop1 = urn;

            //Personel
            List<SelectListItem> per = (from x in db.TblPersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad+" "+x.Soyad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;

            //Müşteriler
            List<SelectListItem> mus = (from x in db.TblMusteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad+" "+x.Soyad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.drop3 = mus;


            return View();
            
        }

        [HttpPost]
        public ActionResult YeniSatis(TblSatislar p)
        {
            var urun = db.TblUrunler.Where(x => x.Id == p.TblUrunler.Id).FirstOrDefault();
            var musteri = db.TblMusteri.Where(x => x.Id == p.TblMusteri.Id).FirstOrDefault();
            var personel = db.TblPersonel.Where(x => x.Id == p.TblPersonel.Id).FirstOrDefault();
            p.TblUrunler = urun;
            p.TblMusteri = musteri;
            p.TblPersonel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            return View();
        }
    }
}