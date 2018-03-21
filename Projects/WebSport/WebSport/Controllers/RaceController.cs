using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSport.Models;

namespace WebSport.Controllers
{
    public class RaceController : Controller
    {
        public DAL.IRepository<Race> RepoRace { get; }

        public RaceController()
        {
            RepoRace = DAL.RepositoryFactory.GetRaceRepository();
        }

        public List<Race> GetRaces()
        {
            return RepoRace.GetAll();
        }

        public ActionResult Index()
        {
            return View(RepoRace.GetAll());
        }

        // GET: Race/Create
        public ActionResult Create()
        {
            return CreateEdit();
        }

        // POST: Race/Create
        [HttpPost]
        public ActionResult Create(CreateEditRaceVM vm)
        {
            try
            {
                if (vm?.Race != null)
                {
                    var organizers = new OrganizerController().GetOrganizers();
                    RepoRace.Create(vm.Race);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateEdit",vm);
            }
        }

        public ActionResult CreateEdit(Race race = null)
        {
            var vm = new CreateEditRaceVM();
            vm.Race = race;
            var repoOrganizer = DAL.RepositoryFactory.GetRepository<Organizer>();
            vm.Organizers = repoOrganizer.GetAll();
            return View("CreateEdit", vm);
        }
    }
}