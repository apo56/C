using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteWeb.Models
{
    public class CreateEditWarriorVM
    {
        public Warrior Warrior { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public int? IdSelectedWeapon { get; set; }
    }
}