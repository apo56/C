using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSport.Controllers
{
    public class RaceController : Controller
    {
        public RaceController()
        {
            RaceRepo = DAL.RepositoryFactory.GetRepository<Race>();
        }

        public DAL.IRepository<Race> RaceRepo { get; }

        // GET: Race
        public ActionResult Index()
        {
            return View(RaceRepo.GetAll());
        }

        // GET: Race/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Race/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Race/Create
        [HttpPost]
        public ActionResult Create(Race race)
        {
            try
            {
                RaceRepo.Insert(race);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Race/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Race/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Race/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Race/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
