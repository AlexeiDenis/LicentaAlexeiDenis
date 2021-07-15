using LicentaAlexeiDenis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicentaAlexeiDenis.Controllers
{
    public class LicitatiiOferteController : Controller
    {
        private Entities db = new Entities();
        // GET: ViewModel
        [HttpGet]
        public ActionResult Detalii(Int32? id)

        {
            //var db = new Entities();
            
            var licitatie = (from a in db.Licitatie
                           where a.IDLicitatie == id
                           select a).FirstOrDefault();

            var oferte = (from a in db.Oferte where a.IDLicitatie == id select a).ToList();

            var model = new Licitatii { _detaliiLicitatie = licitatie, _detaliiOferte = oferte };
            return View(model);
        }

        //public ActionResult CreareBid()
        //{
        //    ViewBag.IDLicitatie = new SelectList(db.Licitatie, "IDLicitatie", "IDLicitatie");
        //    ViewBag.IdUser = new SelectList(db.Useri, "IdUser", "Nume");
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Creare([Bind(Include = "Oferteid,IDLicitatie,IdUser,ValoareBid,DataBid")] Oferte oferte)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Oferte.Add(oferte);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IDLicitatie = new SelectList(db.Licitatie, "IDLicitatie", "IDLicitatie", oferte.IDLicitatie);
        //    ViewBag.IdUser = new SelectList(db.Useri, "IdUser", "Nume", oferte.IdUser);
        //    return View(oferte);
        //}
    }
}