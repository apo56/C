using BO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class Personne : IIdentifiable
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DateTimeRange(-150, 0)]
        public DateTime? DateNaissance { get; set; }

        [NotMapped]
        public string FullName => this.Nom + ' ' + this.Prenom;

        public void CopyValues(Personne p)
        {
            this.Nom = p.Nom;
            this.Prenom = p.Prenom;
            this.Email = p.Email;
            this.DateNaissance = p.DateNaissance;
        }
        
    }
}