using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSportEntity.Models
{
    public class Context : DbContext
    {

        public DbSet<BO.Race> Races { get; set; }

        public DbSet<BO.Competitor> Competitors { get; set; }
        public DbSet<BO.Organizer> Organizers { get; set; }
        //public DbSet<BO.Competitor> Competitor { get; set; }


    }
}
