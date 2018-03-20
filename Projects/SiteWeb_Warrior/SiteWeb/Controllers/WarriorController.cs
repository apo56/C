using BO;
using SiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWeb.Controllers
{

    public class WarriorController : Controller
    {
        private static List<Warrior> warriors = new List<Warrior>();
        private static List<Weapon> weapons;
        // GET: Warrior
        public ActionResult Index()
        {
            var id = 1;
            if (weapons == null)
            {
                weapons = new List<Weapon>
                {
                    new Weapon {Id=id++,Nom="Excalibur",DegatMax=100,DegatMin=50 },
                    new Weapon {Id=id++,Nom="Masamune",DegatMax=150,DegatMin=10 },
                    new Weapon {Id=id++,Nom="DeathWhisper",DegatMax=90,DegatMin=70 },
                    new Weapon {Id=id++,Nom="BF Sword",DegatMax=80,DegatMin=80 },
                    new Weapon {Id=id++,Nom="BloodThirster",DegatMax=200,DegatMin=0 },
                };
            }

            if (warriors.Count == 0)
            {
                warriors.Add(new Warrior
                {
                    Id = 1,
                    NomPropre = "Roger Le Lapinou méchant",
                    Titre = "Barbare des cités"
                });
            }
            return View(warriors);
        }

        // GET: Warrior/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Warrior/Create
        public ActionResult Create()
        {
            var vm = new CreateEditWarriorVM();
            vm.Warrior = new Warrior();
            vm.Weapons = weapons;
            return View(vm);
        }

        // POST: Warrior/Create
        [HttpPost]
        public ActionResult Create(CreateEditWarriorVM vm)
        {
            try
            {
                if (vm?.Warrior != null)
                {
                    vm.Warrior.Id = warriors.Max(w => w.Id) + 1;

                    if (vm.IdSelectedWeapon.HasValue)
                    {
                        var weapon = weapons.SingleOrDefault(
                            w => w.Id == vm.IdSelectedWeapon.Value);
                        vm.Warrior.Weapon = weapon;
                    }

                    warriors.Add(vm.Warrior);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            vm.Weapons = weapons;
            return View(vm);
        }

        /// <summary>
        /// La méthode Edit
        /// </summary>
        /// <param name="id">L'id du warrior à modifier</param>
        /// <returns>La vue Edit</returns>
        public ActionResult Edit(int id)
        {
            var warrior = warriors.SingleOrDefault(w => w.Id == id);
            if (warrior != null)
                return View(warrior);

            return RedirectToAction("Index");
        }

        // POST: Warrior/Edit/5
        [HttpPost]
        public ActionResult Edit(Warrior warrior)
        {
            try
            {
                var warriorDB = warriors.SingleOrDefault(w => w.Id == warrior.Id);
                warriorDB.NomPropre = warrior.NomPropre;
                warriorDB.Titre = warrior.Titre;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warrior/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Warrior/Delete/5
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
