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
    public class CompetitorRepository : IRepository<Competitor>
    {
        private string connexionString;
        private SqlConnection connection;

        private readonly string colId = "id";
        private readonly string colNom = "nom";
        private readonly string colPrenom = "prenom";
        private readonly string colDateNaissance = "date_naissance";
        private readonly string colEmail = "email";
        private readonly string colRace = "race";

        public CompetitorRepository()
        {
            connexionString = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
            connection = new SqlConnection(connexionString);
            connection.Open();
        }

        public void Create(Competitor item)
        {
            try
            {
                SqlCommand rqt = connection.CreateCommand();
                rqt.CommandText = "INSERT INTO competitors(nom,prenom,date_naissance,email,race) VALUES(@Nom,@Prenom,@DateNaissance,@Email,@race);";
                rqt.Parameters.AddWithValue("@Nom", item.Nom);
                rqt.Parameters.AddWithValue("@Prenom", item.Prenom);
                rqt.Parameters.AddWithValue("@DateNaissance", item.DateNaissance);
                rqt.Parameters.AddWithValue("@Email", item.Email);
                rqt.Parameters.AddWithValue("@race", item.Race.Id);
                int nb = rqt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
        }

        public void Delete(Competitor item)
        {
            try
            {
                var command = new SqlCommand("DELETE FROM competitors WHERE id = " + item.Id, connection);
                var reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
        }

        public List<Competitor> GetAll()
        {
            List<Competitor> liste = new List<Competitor>();
            try
            {
                var command = new SqlCommand("SELECT * FROM competitors", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(ItemBuilder(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
            return liste;
        }

        public Competitor GetById(int id)
        {
            Competitor competitor = new Competitor();
            try
            {
                var command = new SqlCommand("SELECT * FROM competitors WHERE id = " + id, connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                    competitor = ItemBuilder(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
            return competitor;
        }

        public void Update(Competitor item)
        {
            try
            {
                var command = new SqlCommand(
                    "UPDATE competitors SET " +
                    "nom = '" + item.Nom + "' ," +
                    "prenom = '" + item.Prenom + "' ," +
                    "date_naissance = '" + item.DateNaissance + "' ," +
                    "email = '" + item.Email + "' ," +
                    "race = " + item.Race.Id + " " +
                    "WHERE id = " + item.Id, connection);
                int nb = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
        }

        public Competitor ItemBuilder(SqlDataReader reader)
        {
            var competitor = new Competitor();
            competitor.Id = reader.GetInt32(reader.GetOrdinal(colId));
            competitor.Nom = reader.GetString(reader.GetOrdinal(colNom));
            competitor.Prenom = reader.GetString(reader.GetOrdinal(colPrenom));
            competitor.DateNaissance = reader.GetDateTime(reader.GetOrdinal(colDateNaissance));
            competitor.Email = reader.GetString(reader.GetOrdinal(colEmail));

            if(null != reader.GetInt32(reader.GetOrdinal(colRace)).ToString())
                competitor.Race = new RaceRepository().GetById(reader.GetInt32(reader.GetOrdinal(colRace)));

            return competitor;
        }
    }
}
