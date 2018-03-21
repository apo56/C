using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vapotage.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public int? PuissanceMAX { get; set; }
        public virtual List<Accumulateur> Accumulateurs { get; set; }

        public string Type = "box";
    }
}