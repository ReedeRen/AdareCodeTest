using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdareCode.Models;
using AdareCode.DAL;
using AdareCode.BL;

namespace AdareCode.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Info = "Login";
            return View();
        }

        // Post : Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ViewModel.UserInfo adminuser)
        {
            if (ModelState.IsValid)
            {
                if (_checker.Check(adminuser.User, adminuser.Password))
                {
                    TempData.Add(_verifiedkey, true);
                    return RedirectToAction("AttendeeList");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login fails");
            }

            ViewBag.Info = "Login";
            return View(adminuser);
        }

        [HttpGet]
        public ActionResult AttendeeList()
        {
            if (!TempData.ContainsKey(_verifiedkey))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.EventListId = new SelectList(_showcollector.GetAllShows(db), "Value", "Text");
            ViewBag.Info = "Attendee";
            return View(new ViewModel.EventSelectViewModel());
        }

        [HttpPost]
        public ActionResult AttendeeList(ViewModel.EventSelectViewModel selectmodel)
        {
            if (ModelState.IsValid)
            {
                int tid = selectmodel.EventListId;
                var tl = db.Clients.Where(p => (p.EmailShowId == tid) || (p.FaxShowId == tid) || (p.PrintShowId == tid)).ToList();
                selectmodel.Attendees = db.Clients.Where(p => (p.EmailShowId == tid) || (p.FaxShowId == tid) || (p.PrintShowId == tid)).ToList();
            }

            ViewBag.EventListId = new SelectList(_showcollector.GetAllShows(db), "Value", "Text");
            ViewBag.Info = "Attendee";
            return View(selectmodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private readonly string _verifiedkey = "Verified";
        private IPasswordChecker _checker = new DummyPasswordChecker();
        private AdareContext db = new AdareContext();
        private ShowCollector _showcollector = new ShowCollector(null);

    }
}
