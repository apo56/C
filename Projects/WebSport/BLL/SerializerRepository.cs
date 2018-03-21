using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Xml.Serialization;

namespace DAL
{
    public class SerializerRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly string path;
        private XmlSerializer xmlSerializer;
        private bool fileExist;

        public SerializerRepository()
        {
            path = Path.GetTempPath() + @"\" + typeof(T).Name + ".xml";
            fileExist = File.Exists(path);
            xmlSerializer = new XmlSerializer(typeof(List<T>));
        }

        public List<T> GetAll()
        {
            if (!fileExist)
                return new List<T>();
            using (var sr = new StreamReader(path))
            {
                return xmlSerializer.Deserialize(sr) as List<T>;
            }
        }

        public T GetById(int id)
        {
            return GetAll().SingleOrDefault(i => i.Id == id);
        }

        public void Create(T item)
        {
            var items = GetAll();
            item.Id = items.Any() ? items.Max(i => i.Id) + 1 : 1;
            items.Add(item);
            Save(items);
        }

        public void Update(T item)
        {
            var items = GetAll();
            var itemDb = items.SingleOrDefault(i => i.Id == item.Id);
            if(itemDb != null)
            {
                items.Remove(itemDb);
                items.Add(item);
            }
            Save(items);
        }

        private void Save(List<T> items)
        {
            using (var sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, items);
            }
        }

        public void Delete(T item)
        {
            var items = GetAll();
            var itemDb = items.SingleOrDefault(i => i.Id == item.Id);
            items.Remove(itemDb);
            Save(items);
        }
    }
}
