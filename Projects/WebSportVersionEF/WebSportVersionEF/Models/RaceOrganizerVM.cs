using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;
using DAL;

namespace WebSportVersionEF.Models
{
    public class RaceOrganizerVM
    {
        public Race Race { get; set; }
        public List<Organizer> Organizers { get; set; }
        public int? IdSelectedOrganizer { get; set; }

        public RaceOrganizerVM(Context db)
        {
            this.Organizers = db.Organizers.ToList();
        }
        public RaceOrganizerVM()
        {
            this.Organizers = new List<Organizer>();
        }
    }
}