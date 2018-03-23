using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace BO
{

    public class Organizer : Personne
    {
        [XmlIgnore]
        public virtual List<Race> Races { get; set; }

        public Organizer()
        {
            this.Races = new List<Race>();
        }

        public void UpdateRace(Race race)
        {
            var cr = Races.SingleOrDefault(r => r.Id == race.Id);
            if (cr != null)
            {
                Races.Remove(cr);
            }
            Races.Add(race);
        }
    }
}