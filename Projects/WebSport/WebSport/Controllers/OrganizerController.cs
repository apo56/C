using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSport.Models;

namespace WebSport.Controllers
{
    public class OrganizerController : Controller
    {
        private DAL.IRepository<Organizer> repo;

        public OrganizerController()
        {
            repo = DAL.RepositoryFactory.GetOrganizerRepository();
        }

        public List<Organizer> GetOrganizers()
        {
            return repo.GetAll();
        }

        // GET: Organizer
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Organizer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organizer/Create
        public ActionResult Create()
        {
            return CreateEdit();
        }

        // POST: Organizer/Create
        [HttpPost]
        public ActionResult Create(CreateEditOrganizerVM vm)
        {
            try
            {
                if (vm?.Organisateur != null)
                {
                    repo.Create(vm.Organisateur);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organizer/Edit/5
        public ActionResult Edit(int id)
        {
            return CreateEdit(repo.GetAll().SingleOrDefault(o => o.Id == id));
        }

        // POST: Organizer/Edit/5
        [HttpPost]
        public ActionResult Edit(Organizer organizer)
        {
            try
            {
                if (organizer != null)
                {
                    var orgDb = repo.GetById(organizer.Id);
                    orgDb.Nom = organizer.Nom;
                    orgDb.Prenom = organizer.Prenom;
                    orgDb.Email = organizer.Email;
                    orgDb.DateNaissance = organizer.DateNaissance;
                    repo.Update(orgDb);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        private ActionResult CreateEdit(Organizer organisateur = null)
        {
            var vm = new CreateEditOrganizerVM();
            vm.Organisateur = organisateur;
            vm.ListeCourses = new RaceController().GetRaces();
            if (organisateur != null && vm.Organisateur.Races != null)
            {
                foreach (var race in vm.Organisateur.Races)
                {
                    vm.MultiSelectListRaces.Add(race.Id);
                }
            }
            return View("CreateEdit", vm);
        }

        // GET: Organizer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organizer/Delete/5
        [HttpPost]
        public ActionResult Delete(Organizer organisateur)
        {
            try
            {
                var orgDb = repo.GetAll().SingleOrDefault(o => o.Id == organisateur.Id);
                repo.Delete(orgDb);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
