using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTNOOB
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Context();
            var arrow = new Arrow();
            arrow.Name = "MoiMeme";
            arrow.Id = 1;
            arrow.Bow = db.Bows.Find(2);
            db.Entry(arrow).State = EntityState.Modified;

            //var arrow2 = db.Arrows.Find(arrow.Id);
            //var oldBow = arrow2.Bow;
            //int pouet = oldBow.Id;
            //var bow = db.Bows.Find(2);
            //db.SaveChanges();
            // bow.Arrows.Add(arrow2);
            db.SaveChanges();
            Console.WriteLine($"Id:{arrow.Id}, Name:{arrow.Name}");
            Console.ReadKey();


            //arrow.Name = "Test2";
            //arrow.Id = 1;
            //var bow = db.Bows.Find(2);
            //bow.Arrows.Add(arrow);
            //db.Entry(arrow).State = EntityState.Modified;
            //db.Entry(bow).State = EntityState.Modified;
            //db.SaveChanges();
            //db.Dispose();
        }
    }

    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Arrow> Arrows { get; set; }
        public DbSet<Bow> Bows { get; set; }
    }
    public class Bow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Arrow> Arrows { get; set; }

        public Bow()
        {
            Arrows = new List<Arrow>();
        }
    }

    public class Arrow
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Bow Bow { get; set; }

    }
}
