using BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public interface IRepo<T>
    {
        string TableName { get; }

        T Create(T obj);
        T CreateORFind(T obj);
        bool Delete(T obj);
        int ExecuteNonQuery(string query);
        void FillObject<O>(O obj, SqlDataReader reader) where O : IIdentifiable;
        T Find(int id);
        T Find(T obj, int id);
        List<T> FindAll(Type type);
        SqlDataReader GetReaderFromCond(string condition = "");
        SqlDataReader GetReader(int? id = default(int?));
        List<T> ListAll();
        List<T> ReadList(List<T> liste);
        bool SaveList(List<T> liste);
        void Update(T obj);

    }
}