using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Tools;
using DAL.Exceptions;
using System.Data.SqlClient;

namespace DAL
{
    public class OrganizerDAO : GenDAO<Organizer>
    {
        public override string TableName => "Organizer";

        public override List<Organizer> ReadList(List<Organizer> liste)
        {
            List<Organizer> orgs = base.ReadList(liste);
            List<Race> races = RepoFactory.GetRepository<Race>().ListAll();
            foreach (var race in races)
            {
                var org = orgs.GetById(race.Organizer.Id);
                if (org != null)
                    org.Races.Add(race);
            }

            return orgs;
        }

        public override Organizer Find(int id)
        {
            var organizer = new Organizer();
            var reader = this.GetReader(id);
            
            while (reader.Read())
            {
                this.FillObject(organizer, reader);
                organizer.DateNaissance = reader.GetDateTime(reader.GetOrdinal("DateNaissance"));
                var repoRaces = RepoFactory.GetRepository<Race>() as RaceDAO;
                var races = repoRaces.ListAllByOrganizer(organizer.Id);
                organizer.Races = races;
            }

            if (organizer.Id == 0)
                throw new OupsException();
            return organizer;
        }

        public override Organizer Create(Organizer obj)
        {
            var nb =  this.ExecuteNonQuery($"Insert into {TableName} (Nom, Prenom, Email, DateNaissance)  VALUES( '{obj.Nom}', '{obj.Prenom}', '{obj.Email}', '{obj.DateNaissance}')");
            return obj;
        }

        public override void Update(Organizer obj)
        {
            this.ExecuteNonQuery($"update {TableName} SET Nom='{obj.Nom}', Prenom='{obj.Prenom}', Email='{obj.Email}', DateNaissance='{obj.DateNaissance}'");
        }

        public override List<Organizer> ListAll()
        {
            var reader = this.GetReader();
            List<Organizer> listOrg = new List<Organizer>();

            while (reader.Read())
            {
                var organizer = new Organizer();
                this.FillObject(organizer, reader);
                organizer.DateNaissance = reader.GetDateTime(reader.GetOrdinal("DateNaissance"));
                listOrg.Add(organizer);
            }
            return listOrg;
        }

    }
}
