using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;


namespace HizliYukle.UI.Areas.admin.Controllers
{
    public class SokakController : Controller
    {
        Repository<Sokak> RepoSokak = new Repository<Sokak>();

        // GET: admin/Sokak
        public ActionResult Index()
        {
            
            return View(RepoSokak.GetAll());
        }

        // GET: admin/Sokak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sokak sokak = RepoSokak.GetBy(g => g.ID == id);
            if (sokak == null)
            {
                return HttpNotFound();
            }
            return View(sokak);
        }

        // GET: admin/Sokak/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: admin/Sokak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,MahalleID")] Sokak sokak)
        {
            if (ModelState.IsValid)
            {
                RepoSokak.Add(sokak);
                return RedirectToAction("Index");
            }

   
            return View(sokak);
        }

        // GET: admin/Sokak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sokak sokak = RepoSokak.GetBy(g => g.ID == id);
            if (sokak == null)
            {
                return HttpNotFound();
            }
      
            return View(sokak);
        }

        // POST: admin/Sokak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,MahalleID")] Sokak sokak)
        {
            if (ModelState.IsValid)
            {
                RepoSokak.Update(sokak);
                return RedirectToAction("Index");
            }

            return View(sokak);
        }

        // GET: admin/Sokak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sokak sokak = RepoSokak.GetBy(g => g.ID == id);
            if (sokak == null)
            {
                return HttpNotFound();
            }
            return View(sokak);
        }

        // POST: admin/Sokak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sokak sokak = RepoSokak.GetBy(g => g.ID == id);
            RepoSokak.Remove(sokak);
            return RedirectToAction("Index");
        }

  
    }
}
