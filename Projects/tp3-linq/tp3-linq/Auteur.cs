﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_linq.BO
{
    public class Auteur
    {
        private List<Facture> _factures;
        public Auteur(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            _factures = new List<Facture>();
        }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Facture> Factures { get { return _factures; } }

        public void addFacture(Facture f)
        {
            this.Factures.Add(f);
        }
        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}
