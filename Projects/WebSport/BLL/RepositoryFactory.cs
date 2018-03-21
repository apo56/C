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
        public static IRepository<T> GetRepository<T>() where T : IIdentifiable
        {
            return new SerializerRepository<T>();
        }

        public static IRepository<Competitor> GetCompetitorRepository()
        {
            return new CompetitorRepository();
        }

        public static IRepository<Race> GetRaceRepository()
        {
            return new RaceRepository();
        }

        public static IRepository<Organizer> GetOrganizerRepository()
        {
            return new OrganizerRepository();
        }



    }
}
