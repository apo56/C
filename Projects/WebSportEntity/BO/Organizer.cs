﻿using System.Collections.Generic;

namespace BO
{

    public class Organizer : Personne
    {
        public virtual List<Race> Races { get; set; }


        public Organizer()
        {
            Races= new List<Race>();
        }
    }
}