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
    public class RaceDAO : GenDAO<Race>
    {
        public override string TableName => "Race";

        public override Race Find(int id)
        {
            var race = new Race();
            var reader = this.GetReader(id);

            while (reader.Read())
            {
                this.FillObject(race, reader);
                race.DateStart = reader.GetDateTime(reader.GetOrdinal("DateStart"));
                race.DateEnd = reader.GetDateTime(reader.GetOrdinal("DateEnd"));
                var organizer = RepoFactory.GetRepository<Organizer>().Find((int)reader["IdOrganizer"]);
                race.Organizer = organizer;
            }

            if (race.Id == 0)
                throw new OupsException();
            return race;
        }

        public override Race Create(Race obj)
        {
            var lastId = this.ExecuteNonQuery($"Insert into {TableName} (Title, Description, DateStart, DateEnd, IdOrganizer)  VALUES( '{obj.Title}', '{obj.Description}', '{obj.DateStart}', '{obj.DateEnd}', '{obj.Organizer.Id}')");
            obj.Id = lastId;
            return obj;
        }

        public override void Update(Race obj)
        {
            this.ExecuteNonQuery($"update {TableName} SET Title='{obj.Title}', Description='{obj.Description}', DateStart='{obj.DateStart}', DateEnd='{obj.DateEnd}', IdOrganizer='{obj.Organizer.Id}'");
        }

        public override List<Race> ListAll()
        {
            var reader = this.GetReader();
            List<Race> races = new List<Race>();

            while (reader.Read())
            {
                var race = new Race();
                this.FillObject(race, reader);
                race.DateStart = reader.GetDateTime(reader.GetOrdinal("DateStart"));
                race.DateEnd = reader.GetDateTime(reader.GetOrdinal("DateEnd"));
                var organizer = RepoFactory.GetRepository<Organizer>().Find((int)reader["IdOrganizer"]);
                race.Organizer = organizer;
                races.Add(race);
            }
            return races;
        }

        public List<Race> ListAllByOrganizer(int id)
        {
            var reader = this.GetReaderFromCond($"Where IdOrganizer={id}");
            List<Race> races = new List<Race>();

            while (reader.Read())
            {
                var race = new Race();
                this.FillObject(race, reader);
                race.DateStart = reader.GetDateTime(reader.GetOrdinal("DateStart"));
                race.DateEnd = reader.GetDateTime(reader.GetOrdinal("DateEnd"));
                var organizer = RepoFactory.GetRepository<Organizer>().Find((int)reader["IdOrganizer"]);
                race.Organizer = organizer;
                races.Add(race);
            }
            return races;
        }
    }
}
