using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataSoftConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            Console.WriteLine("Ajouter numéro de département");

            var NumDepartement = Console.ReadLine();
            var adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=" +NumDepartement;
            //var adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=35";

            
            var json = client.DownloadString(adresse);
            var obj = JsonConvert.DeserializeObject<RootObject>(json);
            Console.WriteLine("vols_avec_armes_armes_a_feu_armes_blanches_ou_par_destination");
            Console.WriteLine(obj.records.Select(record => record.fields.vols_avec_armes_armes_a_feu_armes_blanches_ou_par_destination).FirstOrDefault());
            Console.WriteLine("vols_sans_violence_contre_des_personnes ");
            Console.WriteLine(obj.records.Select(record => record.fields.vols_sans_violence_contre_des_personnes).FirstOrDefault());


            Console.ReadKey();
        }


        public class Refine
        {
            public string departement { get; set; }
        }

        public class Parameters
        {
            public List<string> dataset { get; set; }
            public Refine refine { get; set; }
            public string timezone { get; set; }
            public int rows { get; set; }
            public string format { get; set; }
            public List<string> facet { get; set; }
        }

        public class Geom
        {
            public string type { get; set; }
            public List<List<List<List<double>>>> coordinates { get; set; }
        }

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

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Record
        {
            public string datasetid { get; set; }
            public string recordid { get; set; }
            public Fields fields { get; set; }
            public Geometry geometry { get; set; }
            public DateTime record_timestamp { get; set; }
        }

        public class Facet
        {
            public string name { get; set; }
            public string path { get; set; }
            public int count { get; set; }
            public string state { get; set; }
        }

        public class FacetGroup
        {
            public string name { get; set; }
            public List<Facet> facets { get; set; }
        }

        public class RootObject
        {
            public int nhits { get; set; }
            public Parameters parameters { get; set; }
            public List<Record> records { get; set; }
            public List<FacetGroup> facet_groups { get; set; }
        }

    }
}
