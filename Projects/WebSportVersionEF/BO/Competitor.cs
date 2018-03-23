using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BO
{
    public class Competitor : Personne
    {
        [Required]
        public virtual Race Race { get; set; }
    }
}