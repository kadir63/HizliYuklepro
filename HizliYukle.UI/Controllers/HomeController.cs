using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HizliYukle.UI.Controllers
{ 
    public class HomeController : Controller
    {
       
            Repository<Admin> repoAdmin = new Repository<Admin>();
            Repository<Sokak> repoSokak = new Repository<Sokak>();
            Repository<YukBilgi> repoYuk = new Repository<YukBilgi>();

        public ActionResult Index()
            {
            
            return  View(repoYuk.GetAll().Include(w => w.YukVeren));
        }
        public ActionResult Detay(int GelenID)
        {
            return View(repoYuk.GetAll().Include(w => w.YukVeren).FirstOrDefault(f => f.ID == GelenID));
        }
        public ActionResult Login(string ReturnUrl)
            {
                if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut();
                ViewBag.rtn = ReturnUrl;
                return View();
            }
            [HttpPost, ValidateAntiForgeryToken]
            public ActionResult Login(string kullaniciAdi, string pass, string rURL)
            {
                if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(pass))
                {
                    Admin admin = repoAdmin.GetBy(a => a.KullaniciAdi == kullaniciAdi && a.Sifre == pass);
                    if (admin != null)
                    {
                        FormsAuthentication.SetAuthCookie(kullaniciAdi, true);
                        Session["AdSoyad"] = admin.AdSoyad;
                        if (!string.IsNullOrEmpty(rURL)) return Redirect(rURL);
                        else return Redirect("/admin");
                    }
                    else
                    {
                        ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatalı";
                    }
                }
                else ViewBag.Hata = "Kullanıcı Adı ve Şifre Gerekli";
                return View();
            }

            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
        public ActionResult KayitYukveren()
        {
            return View();
        }
        public ActionResult YukArayan()
        {
            return View();
        }
        public ActionResult DilDegistir(string dil, string returnURL)
        {
            HttpCookie httpCookie = new HttpCookie("CKDil");
            httpCookie.Value = dil;
            Response.Cookies.Add(httpCookie);
            return Redirect(returnURL);
        }
    }
    }
