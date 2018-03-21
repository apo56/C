using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vapoteur.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Marque{ get; set; }
        public int PuissanceMax{ get; set; }


        public List<Accumulateur> Accumulateurs { get; set; }




    }
}