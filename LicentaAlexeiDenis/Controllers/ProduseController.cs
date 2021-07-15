using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LicentaAlexeiDenis;

namespace LicentaAlexeiDenis.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProduseController : Controller
    {
        private Entities db = new Entities();

        // GET: Produse
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var produse = db.Produse.Include(p => p.CategoriiProduse);
            return View(produse.ToList());
        }

        // GET: Produse/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        // GET: Produse/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CodCategorie = new SelectList(db.CategoriiProduse, "CodCategorie", "DenumireCategorie");
            return View();
        }

        // POST: Produse/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProdus,NumeProdus,PretEstimat,CodCategorie,NumeProprietar,Imagine")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Produse.Add(produse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCategorie = new SelectList(db.CategoriiProduse, "CodCategorie", "DenumireCategorie", produse.CodCategorie);
            return View(produse);
        }

        // GET: Produse/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCategorie = new SelectList(db.CategoriiProduse, "CodCategorie", "DenumireCategorie", produse.CodCategorie);
            return View(produse);
        }

        // POST: Produse/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProdus,NumeProdus,PretEstimat,CodCategorie,NumeProprietar,Imagine")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCategorie = new SelectList(db.CategoriiProduse, "CodCategorie", "DenumireCategorie", produse.CodCategorie);
            return View(produse);
        }

        // GET: Produse/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produse.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        // POST: Produse/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produse produse = db.Produse.Find(id);
            db.Produse.Remove(produse);
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
