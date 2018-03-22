using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using  BO;


namespace DAL
{
    public class Context : DbContext
    {
        private Context db ;

        public DbSet<BO.Race> Races { get; set; }

        public DbSet<BO.Competitor> Competitors { get; set; }

        public DbSet<BO.Organizer> Organizers { get; set; }
        

    }
}
