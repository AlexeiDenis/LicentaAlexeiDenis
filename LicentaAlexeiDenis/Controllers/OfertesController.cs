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
    public class OfertesController : Controller
    {
        private Entities db = new Entities();
      
        // GET: Ofertes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var oferte = db.Oferte.Include(o => o.Licitatie).Include(o => o.Useri);
            return View(oferte.ToList());
        }

        // GET: Ofertes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferte oferte = db.Oferte.Find(id);
            if (oferte == null)
            {
                return HttpNotFound();
            }
            return View(oferte);
        }


        // GET: Ofertes/Create
        [Authorize]
        public ActionResult Create()
        {
           
                var res = db.Licitatie.ToList();
                var MyIDLicitatie = res.Where(x => x.DataIncheiere > System.DateTime.Now && System.DateTime.Now >= x.DataPornire).Select(y =>
                     new SelectListItem
                     {
                         Text = Convert.ToString(y.Produse.NumeProdus),
                         Value = Convert.ToString(y.IDLicitatie)
                     }
                );


                ViewBag.IDLicitatie = MyIDLicitatie;
            
         
            ViewBag.IdUser = db.Useri.FirstOrDefault(x => x.Email == User.Identity.Name).IdUser;
           
            return View();
        }

        // POST: Ofertes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Oferteid,IDLicitatie,IdUser,ValoareBid,DataBid")] Oferte oferte)
        {  
            var modelTwo = db.Licitatie.Where(x => x.IDLicitatie == oferte.IDLicitatie).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (DateTime.Now >= modelTwo.DataPornire) { 
                if (modelTwo.DataIncheiere > DateTime.Now)
                {
                    if (modelTwo.PretInitial < oferte.ValoareBid)
                    {
                        modelTwo.PretInitial = (decimal)oferte.ValoareBid;
                        db.Oferte.Add(oferte);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Licitaties");

                    }
                    else { ViewBag.notificare = "Trebuie o suma mai mare decat: " + modelTwo.PretInitial.ToString("#"); }

                }
                else { ViewBag.notificare = "Licitatia s-a incheiat!"; }
                }
                else { ViewBag.notificare = "Inca nu poti licita pentru acest produs"; }
            }
            var res = db.Licitatie.ToList();
            var MyIDLicitatie = res.Where(x => x.DataIncheiere > System.DateTime.Now && System.DateTime.Now >= x.DataPornire).Select(y =>
                 new SelectListItem
                 {
                     Text = Convert.ToString(y.Produse.NumeProdus),
                     Value = Convert.ToString(y.IDLicitatie)
                 }
            );

            ViewBag.IDLicitatie = MyIDLicitatie;
            ViewBag.IdUser = db.Useri.FirstOrDefault(x => x.Email == User.Identity.Name).IdUser; 
            return View(oferte);
        }

        // GET: Ofertes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferte oferte = db.Oferte.Find(id);
            if (oferte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLicitatie = new SelectList(db.Licitatie, "IDLicitatie", "IDLicitatie", oferte.IDLicitatie);
            ViewBag.IdUser = new SelectList(db.Useri, "IdUser", "Nume", oferte.IdUser);
            return View(oferte);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Oferteid,IDLicitatie,IdUser,ValoareBid,DataBid")] Oferte oferte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLicitatie = new SelectList(db.Licitatie, "IDLicitatie", "IDLicitatie", oferte.IDLicitatie);
            ViewBag.IdUser = new SelectList(db.Useri, "IdUser", "Nume", oferte.IdUser);
            return View(oferte);
        }

        // GET: Ofertes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferte oferte = db.Oferte.Find(id);
            if (oferte == null)
            {
                return HttpNotFound();
            }
            return View(oferte);
        }

        // POST: Ofertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferte oferte = db.Oferte.Find(id);
            db.Oferte.Remove(oferte);
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
