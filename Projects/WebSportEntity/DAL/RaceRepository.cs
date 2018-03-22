using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class RaceRepository : IRepository<Race>
    {

        private Context db = new Context();

        public void Delete(int id)
        {
            db.Races.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Race> GetAll()
        {
            var allRaces = db.Races.ToList();
            return allRaces;
        }

        public Race GetById(int id)
        {
            return db.Races.Find(id);
        }

        public void Insert(Race element)
        {
            db.Races.Add(element);
            db.SaveChanges();
        }

        public void Update(Race race)
        {
            var raceUpdate = db.Races.Find(race.Id);

            if (raceUpdate != null)
            {
                raceUpdate.DateEnd = race.DateEnd;
                raceUpdate.DateStart = race.DateStart;
                raceUpdate.Description = race.Description;
                raceUpdate.Title = race.Title;

                db.SaveChanges();
            }
        }


    }
}
