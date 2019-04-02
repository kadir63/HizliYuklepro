using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizliYukle.UI.Controllers
{
    public class YukListeleController : Controller
    {
        Repository<YukBilgi> repoYuk = new Repository<YukBilgi>();

        // GET: YukListele
        public ActionResult Index()
        {
            return View(repoYuk.GetAll().Include(w=>w.YukVeren));
        }
        public ActionResult Detay(int GelenID)
        {
            return View(repoYuk.GetAll().Include(w => w.YukVeren).FirstOrDefault(f=>f.ID==GelenID));
        }
    }
}