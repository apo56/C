using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSport.Models
{
    public class CreateEditOrganizerVM
    {
        public Organizer Organisateur { get; set; }
        public IEnumerable<Race> ListeCourses { get; set; }
        public List<int> MultiSelectListRaces { get; set; }

    }
}