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
using System.Web.Services;

namespace WebSportVersionEF.Controllers
{
    public class CompetitorsController : Controller
    {
        private Context db = new Context();

        // GET: Competitors
        public ActionResult Index()
        {
            return View(db.Competitors.ToList());
        }

        // GET: Competitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // GET: Competitors/Create
        public ActionResult Create()
        {
            var vmc = new CompetitorRaceVM(db);
            return View(vmc);
        }

        // POST: Competitors/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompetitorRaceVM vm)
        {
            vm.Competitor.Race = db.Races.FirstOrDefault(r => r.Id == vm.IdSelectedRace.Value);

            if (ModelState.IsValid || vm.Competitor.Race != null)
            {
                db.Competitors.Add(vm.Competitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return Create();
        }

        // GET: Competitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            var vmc = new CompetitorRaceVM(db);
            vmc.Competitor = competitor;
            vmc.IdSelectedRace = competitor.Race.Id;
            return View("Create", vmc);
        }

        // POST: Competitors/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompetitorRaceVM vm)
        {
            vm.Competitor.Race = db.Races.FirstOrDefault(r => r.Id == vm.IdSelectedRace.Value);
            if (ModelState.IsValid || vm.Competitor.Race != null)
            {
                var CompDb = db.Competitors.Find(vm.Competitor.Id);
                vm.Competitor.Race = db.Races.FirstOrDefault(r => r.Id == vm.IdSelectedRace.Value);
                CompDb.CopyValues(vm.Competitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return Edit(vm.Competitor.Id);
        }

        // GET: Competitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        // POST: Competitors/Delete/5
        [WebMethod]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Competitor competitor = db.Competitors.Find(id);
            db.Competitors.Remove(competitor);
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
