using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepoFactory
    {
        public static IRepo<T> GetRepository<T>() where T : IIdentifiable
        {
            var strName = "DAL." + typeof(T).Name + "DAO";
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var wrappedInstance = Activator.CreateInstance(assemblyName, strName);
            var inst = wrappedInstance.Unwrap() as IRepo<T>;
            return inst;
        }
    }
}
