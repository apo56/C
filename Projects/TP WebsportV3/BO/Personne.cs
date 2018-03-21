﻿using System;

namespace BO
{
    public class Personne : IIdentifiable
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime? DateNaissance { get; set; }
    }
}