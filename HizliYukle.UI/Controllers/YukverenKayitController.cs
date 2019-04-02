using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HizliYukle.UI.Controllers
{
    public class YukverenKayitController : Controller
    {
        Repository<YukVeren> repoYukveren = new Repository<YukVeren>();
        // GET: YukverenKayit
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string MailAddress, string Password)
        {
            if (!string.IsNullOrEmpty(MailAddress) && !string.IsNullOrEmpty(Password))
            {
                YukVeren yukVeren = repoYukveren.GetBy(a => a.Email == MailAddress && a.sifre == Password);
                if (yukVeren != null)
                {
                    FormsAuthentication.SetAuthCookie(MailAddress, true);
                    Session["AdSoyad"] = yukVeren.YetkiliAd + " " + yukVeren.YetkiliSoyad;
                    return Redirect("/");
                }
                else
                {
                    TempData["Hata"] = "Mail Adresi veya Şifre Hatalı";
                    return RedirectToAction("User/Index");
                }
            }
            else TempData["Hata"] = "Mail Adresi veya Şifre boş geçilemez";
            return RedirectToAction("User/Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult YukverenKayit(string Name, string Surname, string MailAddress, string Password, string Password2,string FirmaAd,string Telefon,string Adres)
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Password2) && !string.IsNullOrEmpty(MailAddress))
            {
                if (repoYukveren.GetAll().Any(a => a.Email == MailAddress))
                {
                    TempData["Hata"] = "Mail kullanılamaz.";
                    return Redirect("/YukverenKayit/Index?t=yeni");
                }
                if (Password == Password2)
                {
                    repoYukveren.Add(new YukVeren { YetkiliAd = Name, YetkiliSoyad = Surname, Email = MailAddress, sifre = Password, sifre2 = Password2, Rol = "user",FirmaAd=FirmaAd,Telefon= Telefon, Adres= Adres });
                    YukVeren yukVeren = repoYukveren.GetBy(a => a.Email == MailAddress && a.sifre == Password);
                    FormsAuthentication.SetAuthCookie(MailAddress, true);
                    Session["AdSoyad"] = yukVeren.YetkiliAd + " " +yukVeren.YetkiliSoyad;
                    return Redirect("/");
                }


                else
                { 
                    TempData["Hata"] = "Şifreler uyuşmuyor.";
                    return Redirect("/YukverenKayit/Index?t=yeni");
                }

            }
            else TempData["Hata"] = "Alanları doldurunuz.";
            return Redirect("/YukverenKayit/Index?t=yeni");
        }
    }
}