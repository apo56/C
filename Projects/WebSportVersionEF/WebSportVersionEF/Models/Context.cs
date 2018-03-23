using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BO;


namespace WebSportVersionEF.Models
{
    public class Context : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Race> Races { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        public void GenerateFakesData()
        {
            var rand = new Random();
            for (int i = 0; i < rand.Next(1,10); i++)
            {
                var orgaziner = new Organizer
                {
                    Nom = Faker.Name.FirstName(),
                    Prenom = Faker.Name.LastName(),
                    DateNaissance = Faker.Date.Birthday(),
                    Email = $"mail@{Faker.Name.FirstName()}.com"
                };

                this.Organizers.Add(orgaziner);

                for (int j = 0; j < rand.Next(1, 10); j++)
                {
                    var race = new Race
                    {
                        Title = Faker.Name.FullName(),
                        Description = Faker.Address.StreetName(),
                        Organizer = orgaziner,
                        DateStart = Faker.Date.Forward(),
                        DateEnd = Faker.Date.Forward(),
                    };

                    this.Races.Add(race);

                    for (int k = 0; k < rand.Next(1, 10); k++)
                    {
                        var comp = new Competitor
                        {
                            Nom = Faker.Name.FirstName(),
                            Prenom = Faker.Name.LastName(),
                            DateNaissance = Faker.Date.Birthday(),
                            Email = $"mail@{Faker.Name.FirstName()}.com",
                            Race = race
                        };
                        this.Competitors.Add(comp);
                    }
                }

            }
            this.SaveChanges();
        }

        public void RemoveAllDatas()
        {
            foreach (var item in this.Competitors.ToList())
            {
                this.Competitors.Remove(item);
            }

            foreach (var item in this.Races.ToList())
            {
                this.Races.Remove(item);
            }

            foreach (var item in this.Organizers.ToList())
            {
                this.Organizers.Remove(item);
            }

            this.SaveChanges();
        }
    }
}
