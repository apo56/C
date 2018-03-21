using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BO
{
    [Serializable]
    public class Race : IIdentifiable
    {
        public int Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Commence le")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fini le")]
        public DateTime DateEnd { get; set; }

        public List<Competitor> Competitors { get; set; }

        [XmlIgnore]
        [Display(Name = "Organisateur")]
        public Organizer Organizer { get; set; }
    }
}