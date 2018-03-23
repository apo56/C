using BO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BO
{
    public class Race : IIdentifiable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DateTimeRange(0, 20)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DateTimeRange(0, 20)]
        public DateTime DateEnd { get; set; }

        public virtual List<Competitor> Competitors { get; set; }

        [Required]
        public virtual Organizer Organizer { get; set; }

        public Race()
        {
            this.Competitors = new List<Competitor>();
        }

        public void CopyValues(Race r)
        {
            this.Title = r.Title;
            this.Description = r.Description;
            this.DateStart = r.DateStart;
            this.DateEnd = r.DateEnd;
            this.Competitors = r.Competitors ?? new List<Competitor>();
            this.Organizer = r.Organizer;
        }
        

        public void UpdateCompetitors(Competitor compDB)
        {
            var cr = this.Competitors.SingleOrDefault(r => r.Id == compDB.Id);
            if (cr != null)
            {
                Competitors.Remove(cr);
            }
            Competitors.Add(compDB);
        }
    }
}