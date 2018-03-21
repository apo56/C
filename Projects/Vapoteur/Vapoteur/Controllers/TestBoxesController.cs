using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vapoteur.Models;

namespace Vapoteur.Controllers
{
    public class TestBoxesController : Controller
    {
        private Context db = new Context();

        // GET: TestBoxes
        public ActionResult Index()
        {
            return View(db.Boxes.ToList());
        }

        // GET: TestBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBox testBox = db.Boxes.Find(id);
            if (testBox == null)
            {
                return HttpNotFound();
            }
            return View(testBox);
        }

        // GET: TestBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestBoxes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marque,PuissanceMax,Nom,Test")] TestBox testBox)
        {
            if (ModelState.IsValid)
            {
                db.Boxes.Add(testBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testBox);
        }

        // GET: TestBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBox testBox = db.Boxes.Find(id);
            if (testBox == null)
            {
                return HttpNotFound();
            }
            return View(testBox);
        }

        // POST: TestBoxes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marque,PuissanceMax,Nom,Test")] TestBox testBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testBox);
        }

        // GET: TestBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestBox testBox = db.Boxes.Find(id);
            if (testBox == null)
            {
                return HttpNotFound();
            }
            return View(testBox);
        }

        // POST: TestBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestBox testBox = db.Boxes.Find(id);
            db.Boxes.Remove(testBox);
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
