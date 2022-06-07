using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;
using System.Web.Security;

namespace StokTakipMVC.Controllers
{
    public class GirisYapController : Controller
    {
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TblAdmin t)
        {
            var bilgiler = db.TblAdmin.FirstOrDefault(x => x.Kullanici == t.Kullanici && x.Sifre == t.Sifre);
            if(bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }

            else
            {
                return View();
            }
        }
    }
}