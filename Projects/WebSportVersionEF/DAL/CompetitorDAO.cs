using BO;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CompetitorDAO : GenDAO<Competitor>
    {
        public override string TableName => "Competitor";
        
        public override Competitor Find(int id)
        {
            var competitor = new Competitor();
            var reader = this.GetReader(id);

            while (reader.Read())
            {
                this.FillObject(competitor, reader);
                competitor.DateNaissance = reader.GetDateTime(reader.GetOrdinal("DateNaissance"));
            }

            if (competitor.Id == 0)
                throw new OupsException();
            return competitor;
        }

        public override Competitor Create(Competitor obj)
        {
            var nb = this.ExecuteNonQuery($"Insert into {TableName} (Nom, Prenom, Email, DateNaissance)  VALUES( '{obj.Nom}', '{obj.Prenom}', '{obj.Email}', '{obj.DateNaissance}')");
            return obj;
        }

        public override void Update(Competitor obj)
        {
            var nb = this.ExecuteNonQuery($"update {TableName} SET Nom='{obj.Nom}', Prenom='{obj.Prenom}', Email='{obj.Email}', DateNaissance='{obj.DateNaissance}'");
        }

        public override List<Competitor> ListAll()
        {
            var reader = this.GetReader();
            List<Competitor> listOrg = new List<Competitor>();

            while (reader.Read())
            {
                var competitor = new Competitor();
                this.FillObject(competitor, reader);
                competitor.DateNaissance = reader.GetDateTime(reader.GetOrdinal("DateNaissance"));
                listOrg.Add(competitor);
            }
            return listOrg;
        }

    }
}
