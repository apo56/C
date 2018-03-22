using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryFactory
    {
        
        public static IRepository<Race> GetRepoRace(Context context)
        {
            return new RaceRepository(context);
        }
        public static IRepository<Organizer> GetRepoOrganizer(Context context)
        {
            return new OrganizerRepository(context);
        }
        public static IRepository<Competitor> GetRepoCompetitor(Context context)
        {
            return new CompetitorRepository(context);
        }
    }
}
