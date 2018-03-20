using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {

            var formes = new List<Forme>();
            formes.Add(new Cercle { Rayon = 3 });
            formes.Add(new Rectangle { Largeur = 3, Longueur = 4 });
            formes.Add(new Carre { Longueur = 3 });
            formes.Add(new Triangle { A = 4, B = 5, C = 6 });



            foreach (var forme in formes)
            {

                Console.WriteLine(forme);

            }

            Console.ReadKey();

        }
    }

    public abstract class Forme
    {
        public abstract double Air();
        public abstract double Perimetre();

        public override String ToString()
        {
            String description =$"Aire =  {Air()}  \n";
            description += "Perimetre = " + Perimetre() + Environment.NewLine;                           
            return description;
        }
    }

    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public override double Air()
        {
            double perim = this.Perimetre() / 2;
            double aire = Math.Sqrt(perim * (perim - A)*(perim - B)*(perim - C));
            return aire;

        }
        public override double Perimetre()
        {
            double result = (A + B + C) / 2;
            return result;
        }
        public override string ToString()
        {
            return "Triangle de côté A="+A+" B="+B+ " C="+C+ "\n"+ base.ToString();
        }
    }

    public class Carre : Forme
    {
        public int Longueur { get; set; }


        public override double Air()
        {
            return Longueur * Longueur;
        }
        public override double Perimetre()
        {
            return Longueur * 4;
        }
        public override string ToString()
        {
            return "Carré de côté " + Longueur + "\n" + base.ToString();
        }
    }

    public class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }
        public override double Air()
        {
            return Longueur * Largeur;
        }
        public override double Perimetre()
        {
            return Largeur * 2 + Longueur * 2;
        }
        public override string ToString()
        {
            return "Rectangle de longueur=" + Longueur +" largeur" +Largeur+ "\n" + base.ToString();
        }
    }
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Air()
        {
            return Math.PI * (Rayon * Rayon);
        }
        public override double Perimetre()
        {
            return 2 * Math.PI * Rayon;
        }
        public override string ToString()
        {
            return "Cercle de rayon" + Rayon+ "\n" + base.ToString();
        }
    }






}

