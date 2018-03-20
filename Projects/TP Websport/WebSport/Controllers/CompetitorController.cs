using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSport.Controllers
{
    public class CompetitorController : Controller
    {
        private DAL.IRepository<Competitor> repo;

        public CompetitorController()
        {
            repo = DAL.RepositoryFactory.GetRepository<Competitor>();
        }

        // GET: Competitor
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Competitor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Competitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competitor/Create
        [HttpPost]
        public ActionResult Create(Competitor competitor)
        {
            try
            {
                repo.Insert(competitor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Competitor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Competitor/Edit/5
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

        // GET: Competitor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Competitor/Delete/5
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
