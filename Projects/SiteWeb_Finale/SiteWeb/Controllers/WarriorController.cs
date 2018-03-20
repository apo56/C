using BO;
using SiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tools;

namespace SiteWeb.Controllers
{

    public class WarriorController : Controller
    {
        private static List<Warrior> warriors = new List<Warrior>();
        private static List<Weapon> weapons;
        private static int compteur = 1;
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
                    Id = compteur++,
                    NomPropre = "Roger Le Lapinou méchant",
                    Titre = "Barbare des cités"
                });
            }
            return View(warriors);
        }

        // GET: Warrior/Details/5
        public ActionResult Details(int id)
        {
            return View(warriors.GetById(id));
        }

        // GET: Warrior/Create
        public ActionResult Create()
        {
            return CreateEdit();
        }

        private ActionResult CreateEdit(Warrior warrior = null)
        {
            var vm = new CreateEditWarriorVM();
            vm.Warrior = warrior;
            vm.Weapons = weapons;

            if (warrior != null && warrior.Weapon != null)
                vm.IdSelectedWeapon = warrior.Weapon.Id;

            return View("CreateEdit", vm);
        }

        public ActionResult Edit(int id)
        {
            var warrior = warriors.GetById(id);
            if (warrior != null)
                return CreateEdit(warrior);

            return RedirectToAction("Index");
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
                        var weapon = weapons.GetById(vm.IdSelectedWeapon.Value);
                        vm.Warrior.Weapon = weapon;
                    }
                    warriors.Add(vm.Warrior);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Custom", ex.Message);
            }
            vm.Weapons = weapons;
            return View(vm);
        }



        // POST: Warrior/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditWarriorVM vm)
        {
            try
            {
                var warriorDB = warriors.GetById(vm.Warrior.Id);
                warriorDB.NomPropre = vm.Warrior.NomPropre;
                warriorDB.Titre = vm.Warrior.Titre;

                if (vm.IdSelectedWeapon.HasValue)
                {
                    var weapon = weapons.GetById(vm.IdSelectedWeapon.Value);
                    warriorDB.Weapon = weapon;
                }

                return RedirectToAction("Index");
            }
            catch
            {

            }
            vm.Weapons = weapons;
            return View(vm);
        }

        // GET: Warrior/Delete/5
        public ActionResult Delete(int id)
        {
            return View(warriors.GetById(id));
        }

        // POST: Warrior/Delete/5
        [HttpPost]
        public ActionResult Delete(Warrior warrior)
        {
            try
            {
                var warriorToDelete = warriors.GetById(warrior.Id);
                if (warriorToDelete != null)
                    warriors.Remove(warriorToDelete);
            }
            catch
            {
                //gestion des erreurs
            }
            return RedirectToAction("Index");
        }
    }
}
