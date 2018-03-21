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
    public class RaceRepository : IRepository<Race>
    {
        private string connexionString;
        private SqlConnection connection;

        private readonly string colId = "id";
        private readonly string colTitle = "title";
        private readonly string colDescription = "description";
        private readonly string colDateStart = "date_start";
        private readonly string colDateEnd = "date_end";
        private readonly string colOrganizer = "organizer";

        public RaceRepository()
        {
            connexionString = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
            connection = new SqlConnection(connexionString);
            connection.Open();
        }

        public void Create(Race item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Race item)
        {
            throw new NotImplementedException();
        }

        public List<Race> GetAll()
        {
            var command = new SqlCommand("SELECT * FROM races", connection);
            var reader = command.ExecuteReader();
            List<Race> liste = new List<Race>();
            while (reader.Read())
            {
                var race = new Race();
                race = ItemBuilder(reader);
                liste.Add(race);
            }
            reader.Close();
            return liste;
        }

        public Race GetById(int id)
        {
            Race race = new Race();
            try
            {
                var command = new SqlCommand("SELECT * FROM races WHERE id = " + id, connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                    race = ItemBuilder(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error : " + ex.Message);
            }
            return race;
        }

        public void Update(Race item)
        {
            throw new NotImplementedException();
        }

        public Race ItemBuilder(SqlDataReader reader)
        {
            var race = new Race();
            race.Id = reader.GetInt32(reader.GetOrdinal(colId));
            race.Title = reader.GetString(reader.GetOrdinal(colTitle));
            race.Description = reader.GetString(reader.GetOrdinal(colDescription));
            race.DateStart = reader.GetDateTime(reader.GetOrdinal(colDateStart));
            race.DateEnd = reader.GetDateTime(reader.GetOrdinal(colDateEnd));
            race.Organizer = new OrganizerRepository().GetById(reader.GetInt32(reader.GetOrdinal(colOrganizer)));           
            return race;
        }
    }
}
