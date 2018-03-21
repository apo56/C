using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vapotage.Models;

namespace Vapotage.Controllers
{
    public class AccumulateursController : Controller
    {
        private Context db = new Context();

        // GET: Accumulateurs
        public ActionResult Index()
        {
            return View(db.Accumulateurs.ToList());
        }

        // GET: Accumulateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accumulateur accumulateur = db.Accumulateurs.Find(id);
            if (accumulateur == null)
            {
                return HttpNotFound();
            }
            return View(accumulateur);
        }

        // GET: Accumulateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accumulateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marque,DechargeMax,Capacite")] Accumulateur accumulateur)
        {
            if (ModelState.IsValid)
            {
                db.Accumulateurs.Add(accumulateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accumulateur);
        }

        // GET: Accumulateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accumulateur accumulateur = db.Accumulateurs.Find(id);
            if (accumulateur == null)
            {
                return HttpNotFound();
            }
            return View(accumulateur);
        }

        // POST: Accumulateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marque,DechargeMax,Capacite")] Accumulateur accumulateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accumulateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accumulateur);
        }

        // GET: Accumulateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accumulateur accumulateur = db.Accumulateurs.Find(id);
            if (accumulateur == null)
            {
                return HttpNotFound();
            }
            return View(accumulateur);
        }

        // POST: Accumulateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accumulateur accumulateur = db.Accumulateurs.Find(id);
            db.Accumulateurs.Remove(accumulateur);
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
