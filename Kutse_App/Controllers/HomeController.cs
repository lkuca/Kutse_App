﻿using Kutse_App.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Kutse_App.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            int hour1 = DateTime.Now.Hour;
            ViewBag.Message1 = hour1 < 10 ? "Tere hommikust" : "Tere päevast";
            ViewBag.Message1 = hour1 > 10 ? "Head õhtut": "head ööd";
            
            return View();
        }
        public  ActionResult Kutse()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";
            ViewBag.Message = "Ootan sind oma peole! Tule kindlasti!!!ootan sind!";
            return View();
        }
        [Authorize]
        public ActionResult Roll()
        {
            IList<string> roles = new List<string> { "Roll ei ole maaratud" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                        .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            if (user != null)
                roles = userManager.GetRoles(user.Id);

            // Передача roles в качестве Model в представление
            return View(roles);
        }
        [HttpGet]
        public ActionResult Ankeet()
        {
            return View();
        }
        public ActionResult Ankeet2()
        {
            return View();
        }
        public ActionResult Ankeet2(Peo peo)
        {
            return View(peo);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Meie Saidist.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        

        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl= true;
                WebMail.UserName = "klopak918@gmail.com";
                WebMail.Password = "kfyr wtfb xawn ekms";
                WebMail.From = "klopak918@gmail.com";
                WebMail.Send(guest.Email, "Vastus kutsule",guest.Name + "vastas" +((guest.WillAttend ?? false) ? "tuleb peole" : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }

        }
        PeoContext dabik = new PeoContext();
        [Authorize]
        public ActionResult Peod()
        {
            IEnumerable<Peo> Peod = dabik.Peod;
            return View(Peod);
        }
        Guestcontext db = new Guestcontext();
        //[Authorize]
        [Authorize]
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult crit() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult crit(Peo Peod)
        {
            dabik.Peod.Add(Peod);
            dabik.SaveChanges();
            return RedirectToAction("Peod");

        }
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
            return RedirectToAction("Guests");

        }
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g==null)
            {
                return HttpNotFound();
            }
            return View(g);

            
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g== null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guests");

            
        }
        

    }
}