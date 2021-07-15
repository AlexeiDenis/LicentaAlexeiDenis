using LicentaAlexeiDenis.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LicentaAlexeiDenis.Controllers
{
    public class ConturiController : Controller
    {
        // GET: Conturi 
        public ActionResult Autentificare()
        {
            return View("Autentificare", new Utilizatori());
        }
        [HttpPost]
        public ActionResult Autentificare(Utilizatori model)
        {
            using (var context = new Entities())
            {
                bool Validare = context.Useri.Any(a => a.Email == model.Email && a.Parola == model.Parola);
                

                if (Validare)
                {
                    
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Licitaties");
                }
                ModelState.AddModelError("", "Date incorecte");
                return View();
            }
               
        }
        public ActionResult Delogare()
        {
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Autentificare");
        }

        public ActionResult Inregistrare()
        {
            return View("Inregistrare", new Useri());
        }
        [HttpPost]
        public ActionResult Inregistrare(Useri model)
        {  using ( var context = new Entities())
            {
               
                if (ModelState.IsValid)
                {
                    if (context.Useri.Any(x => x.Email == model.Email))
                    { ViewBag.Notification = "Exista deja un cont cu aceasta adresa de email.";
                        return View();
                    }
                    else
                    {
                        context.Useri.Add(model);             
                        context.SaveChanges();
                       
                        return RedirectToAction("Autentificare");
                    }
             }
            }
            return View();
        }
    }
}


