using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Tools
{
    public static class ListeExtensions
    {
        public static T GetById<T>(this List<T> liste, int id) where T : IIdentifiable
        {
            return liste.SingleOrDefault(l => l.Id == id);
        }
    }
}
