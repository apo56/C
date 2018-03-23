using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAdresse
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var adresse = @"https://api-adresse.data.gouv.fr/search/?q=" + Console.ReadLine();
            var json = client.DownloadString(adresse);
            var obj = JsonConvert.DeserializeObject<RootObject>(json);

        }
    }
    public class Properties
    {
        public string housenumber { get; set; }
        public string label { get; set; }
        public string context { get; set; }
        public double y { get; set; }
        public string citycode { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public double importance { get; set; }
        public double x { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public double score { get; set; }
        public string postcode { get; set; }
        public string street { get; set; }
    }

    public class Geometry
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }

    public class Feature
    {
        public Properties properties { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
    }

    public class RootObject
    {
        public string version { get; set; }
        public string query { get; set; }
        public List<Feature> features { get; set; }
        public string licence { get; set; }
        public int limit { get; set; }
        public string attribution { get; set; }
        public string type { get; set; }
    }

}
