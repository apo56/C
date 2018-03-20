using BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class SerializerRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly string path;
        private readonly XmlSerializer xmlSerializer;
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

        public void Insert(T element)
        {
            var elements = GetAll();
            element.Id = elements.Any() ? elements.Max(e => e.Id) + 1 : 1;

            elements.Add(element);
            Save(elements);
        }

        private void Save(List<T> elements)
        {
            using (var sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, elements);
            }
        }
    }
}
