using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdareCode.Models;
using AdareCode.DAL;

namespace AdareCode.Controllers
{
    public class ShowController : Controller
    {
        private AdareContext db = new AdareContext();

        //
        // GET: /Show/

        public ActionResult Index()
        {
            ViewBag.Info = "Show Index";
            var adareshows = db.AdareShows.Include(a => a.ShowType);
            return View(adareshows.ToList());
        }

        //
        // GET: /Show/Details/5

        public ActionResult Details(int id = 0)
        {
            AdareShow adareshow = db.AdareShows.Find(id);
            if (adareshow == null)
            {
                return HttpNotFound();
            }
            ViewBag.Info = "Show Index";
            return View(adareshow);
        }

        //
        // GET: /Show/Create

        public ActionResult Create()
        {
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Description");
            return View();
        }

        //
        // POST: /Show/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdareShow adareshow)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AdareShows.Add(adareshow);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Please select a proper event date.");
            }

            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Description", adareshow.EventTypeId);
            return View(adareshow);
        }

        //
        // GET: /Show/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AdareShow adareshow = db.AdareShows.Find(id);
            if (adareshow == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Description", adareshow.EventTypeId);
            return View(adareshow);
        }

        //
        // POST: /Show/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdareShow adareshow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adareshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "Id", "Description", adareshow.EventTypeId);
            return View(adareshow);
        }

        //
        // GET: /Show/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    AdareShow adareshow = db.AdareShows.Find(id);
        //    if (adareshow == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adareshow);
        //}

        ////
        //// POST: /Show/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AdareShow adareshow = db.AdareShows.Find(id);
        //    db.AdareShows.Remove(adareshow);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}