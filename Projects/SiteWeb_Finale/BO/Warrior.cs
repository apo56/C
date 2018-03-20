using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Warrior : IIdentifiable
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }

        [Required]
        [Display(Name = "Le blase")]
        public string NomPropre { get; set; }

        [Display(Name = "L'arme")]
        public Weapon Weapon { get; set; }
    }
}