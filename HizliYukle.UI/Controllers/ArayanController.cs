using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizliYukle.UI.Controllers
{
    public class ArayanController : Controller
    {
        Repository<Nakliyeci> repoNakliyeci = new Repository<Nakliyeci>();
        // GET: Arayan
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Kaydet(string ad,string Soyad,string vergidairesi,string vergino,string sifre,string sifre2,string telefon)
        {
            repoNakliyeci.Add(new Nakliyeci { Ad=ad,Soyad=Soyad,VergiDairesi=vergidairesi,VergiNo=vergino,sifre=sifre,sifre2=sifre2,Tel=telefon});
            return Redirect("index");
        }
    }
}