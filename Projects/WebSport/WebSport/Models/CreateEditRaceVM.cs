using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSport.Models
{
    public class CreateEditRaceVM
    {
        public Race Race { get; set; }
        public List<Organizer> Organizers { get; set; }
        public int IdSelectedOrganizer { get; set; }

    }
}