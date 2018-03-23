using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;
using DAL;

namespace WebSportVersionEF.Models
{
    public class CompetitorRaceVM
    {
        public Competitor Competitor { get; set; }
        public List<Race> Races { get; set; }
        public int? IdSelectedRace { get; set; }

        public CompetitorRaceVM(Context db)
        {
            this.Races = db.Races.ToList();
        }

        public CompetitorRaceVM()
        {
            this.Races = new List<Race>();
        }
    }
}