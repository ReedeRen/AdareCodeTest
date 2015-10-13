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
    public class ClientController : Controller
    {
        private AdareContext db = new AdareContext();

        private ShowCollector collector = new ShowCollector(null);

        //
        // GET: /Client/

        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.FaxShow).Include(c => c.EmailShow).Include(c => c.PrintShow);
            return View(clients.ToList());
        }

        //
        // GET: /Client/Create
        [HttpGet]
        public ActionResult Create()
        {
            var faxshows = collector.GetShows(ShowCollector.ShowType.FaxShow, db);
            var emailshows = collector.GetShows(ShowCollector.ShowType.EmailShow, db);
            var printshows = collector.GetShows(ShowCollector.ShowType.PrintShow, db);

            ViewBag.FaxShowId = new SelectList(faxshows, "Value", "Text");
            ViewBag.EmailShowId = new SelectList(emailshows, "Value", "Text");
            ViewBag.PrintShowId = new SelectList(printshows, "Value", "Text");

            return View(new Client());
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Please fill all columns.");
            }

            var faxshows = collector.GetShows(ShowCollector.ShowType.FaxShow, db);
            var emailshows = collector.GetShows(ShowCollector.ShowType.EmailShow, db);
            var printshows = collector.GetShows(ShowCollector.ShowType.PrintShow, db);

            ViewBag.FaxShowId = new SelectList(faxshows, "Value", "Text");
            ViewBag.EmailShowId = new SelectList(emailshows, "Value", "Text");
            ViewBag.PrintShowId = new SelectList(printshows, "Value", "Text");

            return View(client);
        }

        //
        // GET: /Client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            
            var faxshows = collector.GetShows(ShowCollector.ShowType.FaxShow, db);
            var emailshows = collector.GetShows(ShowCollector.ShowType.EmailShow, db);
            var printshows = collector.GetShows(ShowCollector.ShowType.PrintShow, db);

            ViewBag.FaxShowId = new SelectList(db.AdareShows, "Value", "Text", client.FaxShowId);
            ViewBag.EmailShowId = new SelectList(db.AdareShows, "Value", "Text", client.EmailShowId);
            ViewBag.PrintShowId = new SelectList(db.AdareShows, "Value", "Text", client.PrintShowId);

            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            var faxshows = collector.GetShows(ShowCollector.ShowType.FaxShow, db);
            var emailshows = collector.GetShows(ShowCollector.ShowType.EmailShow, db);
            var printshows = collector.GetShows(ShowCollector.ShowType.PrintShow, db);

            ViewBag.FaxShowId = new SelectList(db.AdareShows, "Value", "Text", client.FaxShowId);
            ViewBag.EmailShowId = new SelectList(db.AdareShows, "Value", "Text", client.EmailShowId);
            ViewBag.PrintShowId = new SelectList(db.AdareShows, "Value", "Text", client.PrintShowId);
            
            return View(client);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}