using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSport.Models;

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
            return View(repo.GetById(id));
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
            var vm = new CreateEditCompetitorVM();
            vm.Competitor = repo.GetById(id);
            if (vm.Competitor.Race != null)
            {
                vm.IdSelectedRace = vm.Competitor.Race.Id;
            }

            vm.Races = new RaceController().RaceRepo.GetAll();
            return View(vm);
        }

        // POST: Competitor/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditCompetitorVM vm)
        {
            try
            {
                if (vm.IdSelectedRace.HasValue)
                {
                    vm.Competitor.Race = new RaceController().RaceRepo.GetById(vm.IdSelectedRace.Value);
                }
                repo.Update(vm.Competitor);
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
            return View(repo.GetById(id));
        }

        // POST: Competitor/Delete/5
        [HttpPost]
        public ActionResult Delete(Competitor competitor)
        {
            try
            {
                repo.Delete(competitor.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
