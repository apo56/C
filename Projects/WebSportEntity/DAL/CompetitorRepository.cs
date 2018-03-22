using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class CompetitorRepository : IRepository<Competitor>
    {

        private Context db;

        public CompetitorRepository(Context context)
        {
            db = context;
        }

        public List<Competitor> GetAll()
        {
            var allElements = db.Competitors.ToList();
            return allElements;

        }

        public void Insert(Competitor element)
        {
            db.Competitors.Add(element);
            db.SaveChanges();

        }

        public Competitor GetById(int id)
        {
            return db.Competitors.Find(id);
        }

        public void Delete(int id)
        {
            db.Competitors.Remove(GetById(id));
            db.SaveChanges();
        }

        public void Update(Competitor competitor)
        {
            var Update = db.Competitors.Find(competitor.Id);

            if (Update != null)
            {
                Update.Nom = competitor.Nom;
                Update.Prenom = competitor.Prenom;
                Update.Email = competitor.Email;
                Update.DateNaissance = competitor.DateNaissance;
                Update.Race = competitor.Race;

                db.SaveChanges();
            }
        }
    }
}
