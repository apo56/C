using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace Tools
{
    public class Utils
    {

        private static Dictionary<string, string> alertMessages => ListMessages();

        private static Dictionary<string, string> ListMessages()
        {
            var alertMessages = new Dictionary<string, string>();
            alertMessages.Add("success", "Operation OK");
            alertMessages.Add("error", "Paf une erreur");
            alertMessages.Add("create", "Creation OK");
            alertMessages.Add("delete", "Suppression OK");
            alertMessages.Add("edit", "Update OK");
            
            return alertMessages;
        }

        public static string GetMessage(string type)
        {
            string defaultMessage = "Paramètre introuvable " + type;
            string message = alertMessages.SingleOrDefault(d => d.Key == type).Value ?? defaultMessage;
            byte[] bytes = Encoding.Default.GetBytes(message);
            message = Encoding.UTF8.GetString(bytes);

            return message;
        }

        public static string GetMessageFromRequest(HttpRequestBase r)
        {
            var message = r.QueryString.Get("Message");
            if (message != null && message != "")
            {
                return GetMessage(message);
            }

            return null;
        }

        public static void ListToXml<T>(List<T> liste)
        {
            var xmlSerializer = new XmlSerializer(liste.GetType());
            using (var sw = new StreamWriter($"D:\\cdieze\\{liste.GetType()}.xml"))
            {
                xmlSerializer.Serialize(sw, liste);
            }
        }

        public static List<T> XmlToList<T>(List<T> liste)
        {
            var xmlSerializer = new XmlSerializer(liste.GetType());
            var newList = new List<T>();
            using (var sw = new StreamReader($"D:\\cdieze\\{liste.GetType()}.xml"))
            {
                newList = (List<T>) xmlSerializer.Deserialize(sw);
            }
            return newList;
        }

        public static List<string> GetObjectProperties<T>(T obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            List<string> result = new List<string>();

            foreach (PropertyInfo prop in props)
            {
                result.Add(prop.Name);
            }
            return result;
        }
    }
}
