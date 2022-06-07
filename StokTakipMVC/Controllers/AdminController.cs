using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipMVC.Models.Entity;

namespace StokTakipMVC.Controllers
{
    public class AdminController : Controller
    {
        DBStokTakipMVCEntities1 db = new DBStokTakipMVCEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin p)
        {
            db.TblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}