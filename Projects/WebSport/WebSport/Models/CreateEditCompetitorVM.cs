using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSport.Models
{
    public class CreateEditCompetitorVM
    {
        public Competitor Competitor { get; set; }
        public IEnumerable<Race> Races { get; set; }
        public int? IdSelectedRace { get; set; }

    }
}