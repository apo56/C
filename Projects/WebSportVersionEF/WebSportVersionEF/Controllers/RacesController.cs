using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using WebSportVersionEF.Models;

namespace WebSportVersionEF.Controllers
{
    public class RacesController : Controller
    {
        private Context db = new Context();

        // GET: Races
        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            var vm = new RaceOrganizerVM(db);
            return View(vm);
        }

        // POST: Races/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceOrganizerVM vm)
        {
            vm.Race.Organizer = db.Organizers.FirstOrDefault(o => o.Id == vm.IdSelectedOrganizer.Value);
            if (ModelState.IsValid || vm.Race.Organizer != null)
            {
                vm.Race.Organizer = db.Organizers.FirstOrDefault(o => o.Id == vm.IdSelectedOrganizer.Value);
                db.Races.Add(vm.Race);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return Create();
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            var vm = new RaceOrganizerVM(db);
            vm.Race = race;
            vm.IdSelectedOrganizer = race.Organizer.Id;
            return View("Create", vm);
        }

        // POST: Races/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceOrganizerVM vm)
        {
            
            vm.Race.Organizer = db.Organizers.Find(vm.IdSelectedOrganizer.Value);
            
            if (ModelState.IsValid || vm.Race.Organizer != null)
            {    
                var RaceDb = db.Races.Find(vm.Race.Id);
                RaceDb.CopyValues(vm.Race);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Edit(vm.Race.Id);
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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
