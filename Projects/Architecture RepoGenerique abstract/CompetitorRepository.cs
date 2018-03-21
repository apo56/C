using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CompetitorRepository : ADORepository<Competitor>
    {
        protected override Competitor Construct(SqlDataReader rd)
        {
            return new Competitor
            {
                Id = (int)rd["Id"],
                Nom = (string)rd["Nom"],
                Prenom = (string)rd["Prenom"],
                DateNaissance = DateTime.Parse(rd["DateNaissance"].ToString()),
                Email = (string)rd["Email"]
            };
        }

        protected override string GetUpdateSql(Competitor element)
        {
            return $"UPDATE COMPETITOR SET Nom ='{element.Nom}', Prenom ='{element.Prenom}', DateNaissance ='{element.DateNaissance}', Email ='{element.Email}' " +
                      $"WHERE Id = {element.Id}";
        }

        protected override string GetValues(Competitor element)
        {
            return $"'{element.Id}','{element.Nom}','{element.Prenom}','{element.DateNaissance}','{element.Email}'";
        }
    }
}
