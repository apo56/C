using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrganizerRepository : IRepository<Organizer>
    {
        private string connexionString;
        private SqlConnection connection;

        private readonly string colId = "id";
        private readonly string colNom = "nom";
        private readonly string colPrenom = "prenom";
        private readonly string colDateNaissance = "date_naissance";
        private readonly string colEmail = "email";

        public OrganizerRepository()
        {
            connexionString = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
            connection = new SqlConnection(connexionString);
            connection.Open();
        }

        public void Create(Organizer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Organizer item)
        {
            throw new NotImplementedException();
        }

        public List<Organizer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Organizer GetById(int id)
        {
            Organizer organizer = new Organizer();
            try
            {
                var command = new SqlCommand("SELECT * FROM organizers WHERE id = " + id, connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                    organizer = ItemBuilder(reader);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
            return organizer;
        }

        public void Update(Organizer item)
        {
            throw new NotImplementedException();
        }

        public Organizer ItemBuilder(SqlDataReader reader)
        {
            var organizer = new Organizer();
            organizer.Id = reader.GetInt32(reader.GetOrdinal(colId));
            organizer.Nom = reader.GetString(reader.GetOrdinal(colNom));
            organizer.Prenom = reader.GetString(reader.GetOrdinal(colPrenom));
            organizer.DateNaissance = reader.GetDateTime(reader.GetOrdinal(colDateNaissance));
            organizer.Email = reader.GetString(reader.GetOrdinal(colEmail));
            return organizer;
        }
    }
}
