using System;
using System.Collections.Generic;

namespace BO
{
    public class Race : IIdentifiable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public List<Competitor> Competitors { get; set; }

        public Organizer Organizer { get; set; }
    }
}