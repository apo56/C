using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class Weapon
    {
        public int Id { get; set; }
        public int DegatMin { get; set; }
        public int DegatMax { get; set; }
        public string Nom { get; set; }
        public Warrior Warrior { get; set; }
    }
}