using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;

namespace TpRace.Models
{
    public class CreateEditRaceVM
    {
        public Race race{ get; set; }

        public Organizer organizer { get; set; }
        public List<Competitor> competitors { get; set; }
    }
}