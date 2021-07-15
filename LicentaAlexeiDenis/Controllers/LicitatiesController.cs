using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LicentaAlexeiDenis.Controllers
{
    public class LicitatiesController : Controller
    {
        private Entities db = new Entities();

        // GET: Licitaties
        public ActionResult Index()
        {
            var licitatie = db.Licitatie.Include(l => l.Produse);
            return View(licitatie.ToList().OrderByDescending(l =>l.IDLicitatie));
        }

        // GET: Licitaties/Details/5
        public ActionResult Details(int? id)
        {
      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
                Licitatie licitatie = db.Licitatie.Find(id);
            if (licitatie == null)
            {
                return HttpNotFound();
            }
            return View(licitatie);
        }
        [Authorize(Roles = "Admin")]
        // GET: Licitaties/Create
        public ActionResult Create()
        {
            ViewBag.IDProdus = new SelectList(db.Produse, "IDProdus", "NumeProdus");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLicitatie,DataPornire,DataIncheiere,PretInitial,IDProdus")] Licitatie licitatie)
        {
            if (ModelState.IsValid && licitatie.DataIncheiere > licitatie.DataPornire)
            {
                db.Licitatie.Add(licitatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.text = "Tastati o data de incheiere corecta";
            }

            ViewBag.IDProdus = new SelectList(db.Produse, "IDProdus", "NumeProdus", licitatie.IDProdus);
            return View(licitatie);
        }

        // GET: Licitaties/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitatie licitatie = db.Licitatie.Find(id);
            if (licitatie == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProdus = new SelectList(db.Produse, "IDProdus", "NumeProdus", licitatie.IDProdus);
            return View(licitatie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLicitatie,DataPornire,DataIncheiere,PretInitial,IDProdus")] Licitatie licitatie)
        {
            if (ModelState.IsValid)
            {
                
                    db.Entry(licitatie).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            
            ViewBag.IDProdus = new SelectList(db.Produse, "IDProdus", "NumeProdus", licitatie.IDProdus);
            return View(licitatie);
        }

        // GET: Licitaties/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitatie licitatie = db.Licitatie.Find(id);
            if (licitatie == null)
            {
                return HttpNotFound();
            }
            return View(licitatie);
        }

        // POST: Licitaties/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licitatie licitatie = db.Licitatie.Find(id);
            db.Licitatie.Remove(licitatie);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpPost]
       
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
