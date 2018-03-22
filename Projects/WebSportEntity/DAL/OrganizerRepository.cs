using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    class OrganizerRepository : IRepository<Organizer>
    {

        private Context db;

        public OrganizerRepository(Context context)
        {
            db = context;
        }

        public void Delete(int id)
        {
            db.Organizers.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Organizer> GetAll()
        {
            var allElements = db.Organizers.ToList();
            return allElements;
        }

        public Organizer GetById(int id)
        {
            return db.Organizers.Find(id);
        }

        public void Insert(Organizer element)
        {
            db.Organizers.Add(element);
            db.SaveChanges();
        }

        public void Update(Organizer organizer)
        {
            var OrganizersUpdate = db.Organizers.Find(organizer.Id);

            if (OrganizersUpdate != null)
            {
                OrganizersUpdate.Nom = organizer.Nom;
                OrganizersUpdate.Prenom = organizer.Prenom;
                OrganizersUpdate.Email = organizer.Email;
                OrganizersUpdate.DateNaissance = organizer.DateNaissance;
                OrganizersUpdate.Races = organizer.Races.ToList();


                db.SaveChanges();
            }
        }
    }
}
