namespace TP_Linq_Avance
{
    public class Box
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }

        public Truck Truck { get; set; }

        public override string ToString()
        {
            return $"{Id} V:{Volume} W:{Weight}";
        }
        
    }
}
