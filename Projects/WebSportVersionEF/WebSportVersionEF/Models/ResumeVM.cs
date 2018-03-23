using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSportVersionEF.Models
{
    public class ResumeVM
    {
        public int NbOrganizers { get; set; }
        public int NbRaces { get; set; }
        public int NbCompetitors { get; set; }

        public List<Organizer> LastOrgs { get; set; }
        public List<Race> LastRaces { get; set; }
        public List<Competitor> LastCompts { get; set; }
    }
}