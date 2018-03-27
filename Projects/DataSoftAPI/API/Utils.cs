using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    class Utils
    {
        public static string[] PropertiesFromType(object atype)
        {
            if (atype == null) return new string[] { };
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            List<string> propNames = new List<string>();
            foreach (PropertyInfo prp in props)
            {
                propNames.Add(prp.Name);
            }
            return propNames.ToArray();
        }

    }
}
