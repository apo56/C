using System;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    [Serializable]
    public class Personne : IIdentifiable
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de naissance")]
        public DateTime? DateNaissance { get; set; }
    }
}