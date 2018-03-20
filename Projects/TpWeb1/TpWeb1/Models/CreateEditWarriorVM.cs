using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpWeb1.Models
{
    public class CreateEditWarriorVM
    {
        public Warrior Warrior { get; set; }
        public int? IdSelectedWeapon{ get; set; }
        public IEnumerable<Weapon> Weapons{ get; set; }
    }
}