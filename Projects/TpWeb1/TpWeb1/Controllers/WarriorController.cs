using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using TpWeb1.Models;

namespace TpWeb1.Controllers
{
    public class WarriorController : Controller
    {
        private static List<Warrior> warriors = new List<Warrior>();
        private static List<Weapon> weapons;

        // GET: Warrior
        public ActionResult Index()
        {
            if (warriors.Count == 0)
            {

                warriors.Add(new Warrior
                {
                    Id = 1,
                    NomPropre = "Krom",
                    Titre = "TraqueMort"
                    //Weapon = weapons.FirstOrDefault()
                });
            }

            if (weapons == null)
            {

                int id = 2;
                weapons = new List<Weapon> {
                    new Weapon { Id = 1   , Nom = "None", DegatMin = 0, DegatMax = 0},
                    new Weapon { Id = id++, Nom = "Excalibur", DegatMin = 120, DegatMax = 200 },
                    new Weapon { Id = id++, Nom = "Faiseuse de Veuve", DegatMin = 80, DegatMax = 150 },
                    new Weapon { Id = id++, Nom = "Extermination", DegatMin = 120, DegatMax = 200 },
                    new Weapon { Id = id++, Nom = "Apocalypse", DegatMin = 200, DegatMax = 500},
                    new Weapon { Id = id++, Nom = "Phenix Piercer", DegatMin = 80, DegatMax = 100},
                    new Weapon { Id = id++, Nom = "Suceuse d'âmes", DegatMin = 10, DegatMax = 300}
                    };

            }

            return View(warriors);
        }

        // GET: Warrior/Details/5
        public ActionResult Details(int id)
        {
            var vm = new CreateEditWarriorVM();

            vm.Warrior = warriors.SingleOrDefault(w => w.Id == id);
            if (vm != null)
            {
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        // GET: Warrior/Create
        public ActionResult Create()
        {
            return CreateEdit();
        }

        public ActionResult CreateEdit(Warrior warrior = null)
        {
            var vm = new CreateEditWarriorVM();
            vm.Warrior = warrior;
            vm.Weapons = weapons;

            if (warrior != null && warrior.Weapon.Id != null)
            {
                vm.IdSelectedWeapon = warrior.Weapon.Id;
            }
            return View("CreateEdit", vm);
        }


        // POST: Warrior/Create
        [HttpPost]
        public ActionResult Create(CreateEditWarriorVM vm)
        {
            try
            {       //vm? si vm =null pas de test
                if (vm?.Warrior != null)
                {
                    vm.Warrior.Id = warriors.Max(w => w.Id) + 1;

                    // TODO: Add insert logic here
                    if (vm.IdSelectedWeapon.HasValue)
                    {
                        var weapon = weapons
                                     .FirstOrDefault(w => w.Id == vm.IdSelectedWeapon.Value);
                        vm.Warrior.Weapon = weapon;
                    }
                }
                warriors.Add(vm.Warrior);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warrior/Edit/5
        public ActionResult Edit(int id)
        {
            CreateEditWarriorVM vm = new CreateEditWarriorVM();
            vm.Warrior = warriors.SingleOrDefault(w => w.Id == id);
            vm.Weapons = weapons;
            if (vm != null)
            {
                if (vm.IdSelectedWeapon == null)
                {
                    vm.IdSelectedWeapon = weapons.FirstOrDefault().Id;
                    return View(vm);
                }
                else
                {
                    return View(vm);
                }

            }
            return RedirectToAction("Index");
        }

        // POST: Warrior/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditWarriorVM vm)
        {
            try
            {

                // TODO: Add update logic here
                var warriorDB = warriors.SingleOrDefault(w => w.Id == vm.Warrior.Id);
                warriorDB.NomPropre = vm.Warrior.NomPropre;
                warriorDB.Titre = vm.Warrior.Titre;
                warriorDB.Weapon = vm.Warrior.Weapon;

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
            try
            {
                // TODO: Add delete logic here
                var warriorDB = warriors.SingleOrDefault(w => w.Id == id);
                warriors.Remove(warriorDB);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Warrior/Delete/5
        [HttpPost]
        public ActionResult Delete(Warrior warrior)
        {
            try
            {
                // TODO: Add delete logic here
                var warriorDB = warriors.SingleOrDefault(w => w.Id == warrior.Id);
                warriors.Remove(warriorDB);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
