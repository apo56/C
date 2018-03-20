using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;
namespace TpRace.Models
{
    public class CreateEditOrganizerVM
    {
        public Organizer Organizer { get; set; }
        public List<Race>races { get; set; }

    }
}