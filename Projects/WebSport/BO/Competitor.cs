using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BO
{
    public class Competitor : Personne
    {
        [XmlIgnore]
        [Display(Name = "Inscrit à la course")]
        public Race Race { get; set; }
    }
}