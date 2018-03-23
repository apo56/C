using BO;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace DAL
{
    public abstract class GenDAO<T> : IRepo<T> where T : IIdentifiable
    {
        private List<T> elements;
        protected SqlConnection connection;
        private System.Diagnostics.Stopwatch timer;
        private int objId;

        public virtual string TableName => "OverrideMe!!";

        public GenDAO()
        {
            objId = new Random().Next(99999);
            timer = System.Diagnostics.Stopwatch.StartNew();
            File.AppendAllText(@"d:\cdieze\counter.txt", $"Start ({objId}) : {timer.ElapsedMilliseconds}" + Environment.NewLine);
            InitConnection();
        }

        ~GenDAO() 
        {
            timer.Stop();
            var elapsedMs = timer.ElapsedMilliseconds;
            File.AppendAllText(@"d:\cdieze\counter.txt", $"Stop ({objId}) : {elapsedMs}" + Environment.NewLine);
        }
        
        private void InitConnection()
        {
            if (connection == null)
            {
                var connexionString = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
                connection = new SqlConnection(connexionString);
                connection.Open();
            }
        }

        [Obsolete("Ancienne méthode pour liste xml")]
        private List<T> LoadAll()
        {
            throw new NotImplementedException();
        }
        
        public virtual List<T> ListAll()
        {
            throw new OverrideMeException();
        }

        public virtual List<T> ListAll(string condition)
        {
            throw new OverrideMeException();
        }

        public virtual T CreateORFind(T obj)
        {
            T finded;
            try
            {
                finded = this.Find(obj, obj.Id);
            }
            catch (Exception)
            {
                finded = this.Create(obj);
            }
            return finded;
        }

        public virtual T Create(T obj)
        {
            throw new OverrideMeException();
        }

        public SqlDataReader GetReader(int? id = null)
        {
            var cond = "";
            if (id.HasValue)
            {
                cond = $"where Id = {id.Value}";
            }

            var command = new SqlCommand($"Select * from {TableName} {cond}", connection);
            return command.ExecuteReader();
        }

        public SqlDataReader GetReaderFromCond(string condition = "")
        {
            var command = new SqlCommand($"Select * from {TableName} {condition}", connection);
            return command.ExecuteReader();
        }

        public virtual T Find(int id)
        {
            throw new OverrideMeException();
        }

        public virtual T Find(T obj, int id)
        {
            var reader = this.GetReader(id);
            if (!reader.HasRows)
                throw new Exception($"Id introuvable pour la table {TableName} : {id}");
            reader.NextResult();
            this.FillObject(obj, reader);
            
            return obj;
        }

        public virtual List<T> FindAll(Type type)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T obj)
        {
            var elementDb = elements.SingleOrDefault(e => e.Id == obj.Id);
            if (elementDb != null)
            {
                elements.Remove(elementDb);
                elements.Add(obj);
                Save();
                return;
            }

            throw new OupsException();
        }

        public virtual bool Delete(T obj)
        {
            var command = new SqlCommand($"Delete from {TableName} where Id = {obj.Id}", connection);
            var count = command.ExecuteNonQuery();

            return count > 0;
        }

        public virtual bool SaveList(List<T> liste)
        {
            var isOk = true;

            try
            {
                Utils.ListToXml(liste);
            }
            catch (Exception e)
            {

                isOk = false;
            }

            return isOk;
        }

        public virtual List<T> ReadList(List<T> liste)
        {
            throw new OupsException();
        }

        private void Save()
        {
            this.SaveList(elements);
        }


        public virtual void FillObject<O>(O obj, SqlDataReader reader) where O : IIdentifiable
        {
            var listProp = Utils.GetObjectProperties(obj);
            Type type = obj.GetType();

            foreach (var prop in listProp)
            {
                try
                {
                    if (obj.Id == 0)
                        obj.Id = (int)reader["Id"];

                    PropertyInfo objProp = type.GetProperty(prop);
                    objProp.SetValue(obj, (string)reader[prop]);
                }
                catch
                {
                }
            }
        }

        public virtual int ExecuteNonQuery(string query)
        {
            var command = new SqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }
        
    }
}
