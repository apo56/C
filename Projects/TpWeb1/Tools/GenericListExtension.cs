using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class GenericListExtension
    {
        public  static T GetById<T>(this List<> identifiables, int id) where T : IIdentifiable
        {
            return identifiables.SingleOrDefault(i => i.Id == id);
        }
    }

    internal interface IIdentifiable
    {
    }
}
