using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Warrior 
    {
        public int Id { get; set; }

        [Required, MaxLength(25), MinLength(4),Display(Name = "Titre")]
        public String Titre { get; set; }

        [Required, MaxLength(25), MinLength(4), Display(Name = "Pseudo")]
        public String NomPropre { get; set; }
        

        public Weapon Weapon { get; set; }
    }
}