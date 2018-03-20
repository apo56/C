using System.Collections.Generic;
using System.Linq;

namespace TP_Linq_Avance
{
    public class Truck
    {
        public static double VolumeMax;

        public int Id { get; set; }

        public double Volume { get; set; }
        //OR
        //public double Volume => Boxes.Sum(b => b.Volume);

        public double Weight { get; set; }
        //OR
        //public double Weight => Boxes.Sum(b => b.Weight );

        public List<Box> Boxes { get; } = new List<Box>();

        public override string ToString()
        {
            return $"{Id} V:{Volume} W:{Weight} bCount:{Boxes.Count}";
        }
        public bool AddBoxe(Box box)
        {
            if (Volume + box.Volume < VolumeMax) return false;

            this.Boxes.Add(box);
            box.Truck = this;
            this.Volume += box.Volume;
            this.Weight += box.Weight;
            return true;
        }
    }
}
