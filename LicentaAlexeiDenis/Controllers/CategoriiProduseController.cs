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
    public class CategoriiProduseController : Controller
    {
        private Entities db = new Entities();

        // GET: CategoriiProduse
       
        public ActionResult Index()
        {
            return View(db.CategoriiProduse.ToList());
        }

        // GET: CategoriiProduse/Details/5
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriiProduse categoriiProduse = db.CategoriiProduse.Find(id);
            if (categoriiProduse == null)
            {
                return HttpNotFound();
            }
            return View(categoriiProduse);
        }

        // GET: CategoriiProduse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriiProduse/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCategorie,DenumireCategorie")] CategoriiProduse categoriiProduse)
        {
            if (ModelState.IsValid)
            {
                db.CategoriiProduse.Add(categoriiProduse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriiProduse);
        }

        // GET: CategoriiProduse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriiProduse categoriiProduse = db.CategoriiProduse.Find(id);
            if (categoriiProduse == null)
            {
                return HttpNotFound();
            }
            return View(categoriiProduse);
        }

        // POST: CategoriiProduse/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCategorie,DenumireCategorie")] CategoriiProduse categoriiProduse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriiProduse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriiProduse);
        }

        // GET: CategoriiProduse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriiProduse categoriiProduse = db.CategoriiProduse.Find(id);
            if (categoriiProduse == null)
            {
                return HttpNotFound();
            }
            return View(categoriiProduse);
        }

        // POST: CategoriiProduse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriiProduse categoriiProduse = db.CategoriiProduse.Find(id);
            db.CategoriiProduse.Remove(categoriiProduse);
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
