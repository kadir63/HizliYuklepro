using HizliYukle.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizliYukle.UI.Controllers
{
    public class AJAXController : Controller
    {
        // GET: AJAX
        MyContext db = new MyContext();
        public ActionResult Index(string adsoyad, int yas)
        {
            string rtn = "Selam size: " + adsoyad;
            if (yas > 35) rtn += " yolun yarısı geçilmiş";
            else rtn += " henüz gençsiniz";
            return Content(rtn);
        }
        public ActionResult Sehirler()
        {
            //string[] sehirList = { "İstanbul", "Ankara", "Konya", "Bursa", "İzmit" };

            return Json(db.Sehir.Select(s => new { s.ID, s.Title }), JsonRequestBehavior.AllowGet);
            //return Json(sehirList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ilceler(int Plaka)
        {
            return Json(db.Ilce.Where(w => w.SehirKeyIlceKey == Plaka), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Mahalleler(int ilceID)
        {
            return Json(db.Mahalle.Where(w => w.MahalleKey == ilceID), JsonRequestBehavior.AllowGet);
        }
    }
}