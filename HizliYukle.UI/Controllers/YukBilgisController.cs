using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HizliYukle.BOL.Entites;
using HizliYukle.DAL.Contexts;

namespace HizliYukle.UI.Controllers
{
    public class YukBilgisController : Controller
    {
        private MyContext db = new MyContext();

        // GET: YukBilgis
        public ActionResult Index()
        {
            
            ViewBag.Sehir = new SelectList(db.Sehir.ToList(), "SehirKey", "Title");
            var yukBilgi = db.YukBilgi.Include(y => y.YukVeren);
            return View(yukBilgi.ToList());
        }

        // GET: YukBilgis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YukBilgi yukBilgi = db.YukBilgi.Find(id);
            if (yukBilgi == null)
            {
                return HttpNotFound();
            }
            return View(yukBilgi);
        }

        // GET: YukBilgis/Create
        public ActionResult Create()
        {
            ViewBag.YukVerenID = new SelectList(db.YukVeren, "ID", "FirmaAd");
            return View();
        }

        // POST: YukBilgis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Aciklama,YuklemeSehri,YuklemeIlce,BosaltmaSehri,BosaltmaIlce,YukuYuklemeTarih,YukVerenID")] YukBilgi yukBilgi)
        {
            if (ModelState.IsValid)
            {
                db.YukBilgi.Add(yukBilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YukVerenID = new SelectList(db.YukVeren, "ID", "FirmaAd", yukBilgi.YukVerenID);
            return View(yukBilgi);
        }

        // GET: YukBilgis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YukBilgi yukBilgi = db.YukBilgi.Find(id);
            if (yukBilgi == null)
            {
                return HttpNotFound();
            }
            ViewBag.YukVerenID = new SelectList(db.YukVeren, "ID", "FirmaAd", yukBilgi.YukVerenID);
            return View(yukBilgi);
        }

        // POST: YukBilgis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Aciklama,YuklemeSehri,YuklemeIlce,BosaltmaSehri,BosaltmaIlce,YukuYuklemeTarih,YukVerenID")] YukBilgi yukBilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yukBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YukVerenID = new SelectList(db.YukVeren, "ID", "FirmaAd", yukBilgi.YukVerenID);
            return View(yukBilgi);
        }

        // GET: YukBilgis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YukBilgi yukBilgi = db.YukBilgi.Find(id);
            if (yukBilgi == null)
            {
                return HttpNotFound();
            }
            return View(yukBilgi);
        }

        // POST: YukBilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YukBilgi yukBilgi = db.YukBilgi.Find(id);
            db.YukBilgi.Remove(yukBilgi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
