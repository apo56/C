using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var nb = Enumerable.Range(0, 20);
            var predicate = new Func<int, bool>(i => i % 2 == 0);
            var FirstPair = nb.First(predicate);
            var LastPair = nb.First(predicate);

            try
            {
                var impossible = nb.FirstOrDefault(i => i > 100);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            try
            {
                var impossible = nb.Single(i => i > 100);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            // TP Suivant
            var random = new Random();
            var appartements = Enumerable.Range(1, 10).
                Select(i => new Appartement
                {   Num = i ,
                    Pieces = Enumerable.Range(0, random.Next(5)).ToList()
                });

            var maxPieces = appartements.Max(a => a.Pieces.Count );
            var tMax = appartements.Where(a => a.Pieces.Count == maxPieces);
            var piecesSelect = appartements.Select(a => a.Pieces);
            var piecesSelectmany = appartements.SelectMany(a => a.Pieces);

            var piecesOrderer = piecesSelectmany.OrderByDescending(p => p);

            piecesOrderer.ToList().ForEach(i => Console.WriteLine(i));
            //OU
            piecesOrderer.ToList().ForEach(Console.WriteLine);

            var tousLesAppartementsMax = appartements.GroupBy(a => a.Pieces.Count);
            foreach (var item in tousLesAppartementsMax)
            {
                Console.WriteLine(item.Key );
            }
            // a retenir
            // var tMax = appartements.Where(a => a.Pieces.Count == maxPieces);
            // var piecesSelect = appartements.Select(a => a.Pieces);
            // var piecesSelectmany = appartements.SelectMany(a => a.Pieces);
            // piecesOrderer.ToList().ForEach(i => Console.WriteLine(i));


        }


        public class Appartement
        {

            public int Num { get; set; }

            public List<int> Pieces { get; set; }
        }
        public class Pieces
        {

            public int Num { get; set; }

            public String Nom { get; set; }
        }
    }
}
