using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public abstract class ADORepository<T> : IRepository<T> where T : IIdentifiable, new()
    {
        private readonly string connexionString = @"server=localhost;database=TD_ADO;user id=sa; password=Pa$$w0rd";

        public List<T> GetAll()
        {
            var results = new List<T>();
            try
            {
                var connection = new SqlConnection(connexionString);
                connection.Open();
                var command = new SqlCommand($"Select * from {typeof(T).Name}", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    results.Add(Construct(reader));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return results;
        }
        protected abstract T Construct(SqlDataReader reader);

        public void Insert(T element)
        {
            var connection = new SqlConnection(connexionString);
            connection.Open();
            var command = new SqlCommand($"Insert into {typeof(T).Name}  VALUES({GetValues(element)})", connection);
            var count = command.ExecuteNonQuery();
        }

        protected abstract string GetValues(T element);

        public T GetById(int id)
        {
            return GetAll().SingleOrDefault(g => g.Id == id);
        }

        public void Update(T element)
        {
            var connection = new SqlConnection(connexionString);
            connection.Open();
            var command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = GetUpdateSql(element);

            var count = command.ExecuteNonQuery();
        }

        protected abstract string GetUpdateSql(T element);

        public void Delete(int id)
        {
            var connection = new SqlConnection(connexionString);
            connection.Open();
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM  {typeof(T).Name} WHERE Id={id}";
            var count = command.ExecuteNonQuery();
        }
    }
}
