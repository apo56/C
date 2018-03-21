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
            repo = DAL.RepositoryFactory.GetCompetitorRepository();
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
            return CreateEdit();
        }

        // POST: Competitor/Create
        [HttpPost]
        public ActionResult Create(CreateEditCompetitorVM vm)
        {
            try
            {
                var races = new RaceController().GetRaces();
                vm.Competitor.Race = races.SingleOrDefault(r => r.Id == vm.IdSelectedRace);
                repo.Create(vm.Competitor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateEdit", vm);
            }
        }

        // GET: Competitor/Edit/5
        public ActionResult Edit(int id)
        {
            return CreateEdit(repo.GetById(id));
        }

        // POST: Competitor/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditCompetitorVM vm)
        {
            try
            {
                if(vm.IdSelectedRace.HasValue || vm.Competitor.Race != null)
                {
                    vm.Competitor.Race = new RaceController().RepoRace.GetById(vm.IdSelectedRace.Value);
                }
                
                repo.Update(vm.Competitor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateEdit",vm);
            }
        }

        private ActionResult CreateEdit(Competitor competitor = null)
        {
            var vm = new CreateEditCompetitorVM();
            if(competitor != null)
            {
                vm.Competitor = repo.GetById(competitor.Id);
                if (vm.Competitor.Race != null)
                    vm.IdSelectedRace = vm.Competitor.Race.Id;
            }
            vm.Races = new RaceController().RepoRace.GetAll();

            return View("CreateEdit", vm);
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
                repo.Delete(competitor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
