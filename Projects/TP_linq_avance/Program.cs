using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Linq_Avance
{
    public class Program
    {
        public static double VolumeMax = 100d;
        public static void espace()
        {
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Truck.VolumeMax = VolumeMax;

            var dir = Directory.GetParent(Environment.CurrentDirectory).Parent;
            Console.SetIn(new StreamReader(dir.FullName + @"\IN.txt"));

            var boxCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box>(boxCount);
            var trucks =  Enumerable.Range(0, 100)
                                    .Select(i => new Truck { Id = i })
                                    .ToList();

            for (var i = 0; i < boxCount; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                boxes.Add(new Box
                {
                    Id = i,
                    Weight = double.Parse(inputs[0]),
                    Volume = double.Parse(inputs[1]),
                });
            }

            // Afficher la moyenne des poids des boxes;
            Console.WriteLine($"poids des boxes moyen: {boxes.Average(b=>b.Weight)}");

            espace();
            // Afficher le volume moyen des boxes;
            Console.WriteLine($"volume moyen des boxes: {boxes.Average(b => b.Volume)}");

            espace();
            // Afficher la densité moyenne des boxes;
            Console.WriteLine($"densité moyenne des boxes: {boxes.Average(b => b.Weight/b.Volume)}");

            espace();
            // Afficher l'id de la box de plus petit volume et le volume correspondant
            //Console.WriteLine($"id de la box de plus petit volume et le volume correspondant:");
            /*var minBoxe =boxes.GroupBy(b => b.Volume)
                        .OrderByDescending(key => key.Key)
                        .FirstOrDefault()
                        .Select(b => b.Id)
                        .ToList()
                        .ForEach(Console.WriteLine);
            */
            //OR
            var minBoxe =  boxes.OrderBy(b => b.Volume).FirstOrDefault();
            Console.WriteLine($"id de la box de plus petit volume: {minBoxe.Id}  et le volume correspondant:{minBoxe.Volume}");


                espace();
            // Afficher l'id de la box de poids max et le poids correspondant
            var maxBoxe = boxes.OrderBy(b => b.Weight).FirstOrDefault();
            Console.WriteLine($"id de la box de poids max: {maxBoxe.Id} et le poids correspondant: {maxBoxe.Volume}");

            espace();
            // remplir 10 trucks avec le poids maximum possible, tout en restant en dessous de VolumeMax par truck;
            // afficher le poids total de ces 10 trucks;
            // afficher le volume moyen restant dans les 10 trucks;
            var trucks10 = Enumerable.Range(0, 10)
                                    .Select(i => new Truck { Id = i })
                                    .ToList();

            double poidsTotal = 0;
            double volumeRestantTotal = 0;
            foreach (var truck in trucks10)
            {
                //remplir camion
               var volumeRestantTruck = trucks10.Where(t=>t.Id==truck.Id).Select(t=>t.Volume).FirstOrDefault();
            //double volumeRestantTruck = trucks10.Select(t => t.Volume).Cast<double>();

                foreach (var boxe in boxes.Where(b=>b.Truck==null))
                {
                   if (volumeRestantTruck < VolumeMax)
                    {
                            truck.Boxes.Add(boxe);
                            boxe.Truck = truck;

                            poidsTotal += boxe.Weight;
                            volumeRestantTotal += VolumeMax - volumeRestantTruck;
                        }
                        else
                        {
                            break;
                        }
                    
                    
                }
                Console.WriteLine($"Truck{ truck}");
            };
            espace();
            Console.WriteLine($"poidsTotal:{poidsTotal}");
            espace();
            Console.WriteLine($"volumeRestantTotal:{volumeRestantTotal}");
            espace();
            // mettre la totalité des boites dans les camions pour utiliser le moins de camions possible
            // combien y a t'il de camions vides sur les 100 ?
            // combien pourrait on en avoir en théorie ?

            Console.ReadKey();
        }
    }
}
