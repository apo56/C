using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    
        public class Fields
        {
            public string departement { get; set; }
            public int vols_dans_les_vehicules { get; set; }
            public int cambriolages_de_logement { get; set; }
            public string libelle_departement { get; set; }
            public int nombre_de_logements { get; set; }
            public List<double> geo_point_2d { get; set; }
            public int vols_avec_armes_armes_a_feu_armes_blanches_ou_par_destination { get; set; }
            public int vols_sans_violence_contre_des_personnes { get; set; }
            public int vols_d_accessoires_sur_vehicules { get; set; }
            public int coups_et_blessures_volontaires_sur_personnes_de_15_ans_ou_plus { get; set; }
            public Geom geom { get; set; }
            public int vols_de_vehicules_automobiles_ou_deux_roues_motorises { get; set; }
            public int vols_violents_sans_arme { get; set; }
            public int population { get; set; }
        }
    
}
