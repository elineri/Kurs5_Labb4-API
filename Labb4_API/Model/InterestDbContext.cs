using Labb4_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Model
{
    public class InterestDbContext : DbContext
    {
        public InterestDbContext(DbContextOptions<InterestDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<PersonInterestLink> PersonInterestLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Person
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, FirstName = "Elin", LastName = "Ericstam", PhoneNumber = "0701234567" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, FirstName = "Göran", LastName = "Svensson", PhoneNumber = "0713456789" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, FirstName = "Klas", LastName = "Johansson", PhoneNumber = "0739834572" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 4, FirstName = "Siv", LastName = "Skog", PhoneNumber = "0742927172" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 5, FirstName = "Peter", LastName = "Bok", PhoneNumber = "0701635567" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 6, FirstName = "Amanda", LastName = "Ask", PhoneNumber = "0701234123" });

            // Seed Interest
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 1, InterestName = "Floorball", Description = "Floorball is a type of floor hockey with five players and a goalkeeper in each team" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 2, InterestName = "Dogs", Description = "The dog or domestic dog is a domesticated descendant of the wolf which is characterized by an upturning tail" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 3, InterestName = "Valheim", Description = "Valheim is a survival and sandbox video game by the Swedish developer Iron Gate Studio" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 4, InterestName = "World of Warcraft", Description = "World of Warcraft is a massively multiplayer online role-playing game released in 2004 by Blizzard Entertainment" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 5, InterestName = "Interior Design", Description = "Interior design is the art and science of enhancing the interior of a building to achieve a healthier and more aesthetically pleasing environment for the people using the space" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 6, InterestName = "Carpenter", Description = "Carpenters are skilled artisans who construct, erect, install and renovate structures made of wood and other materials, ranging from kitchen cabinets to building frameworks" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 7, InterestName = "Fashion", Description = "Fashion is a form of self-expression and autonomy at a particular period and place and in a specific context, of clothing, footwear, lifestyle, accessories, makeup, hairstyle, and body posture" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 8, InterestName = "Counter-Strike", Description = "Counter-Strike is a series of multiplayer first-person shooter video games in which teams of terrorists battle to perpetrate an act of terror while counter-terrorists try to prevent it" });

            // Seed Website
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 1, LinkDescription = "International Floorball Federation", Link = "https://floorball.sport/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 2, LinkDescription = "National Geographic Dog facts", Link = "https://www.nationalgeographic.com/animals/mammals/facts/domestic-dog" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 3, LinkDescription = "Dog breeds", Link = "https://dogtime.com/dog-breeds/profiles" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 4, LinkDescription = "Valheim wiki", Link = "https://valheim.fandom.com/wiki/Valheim_Wiki" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 5, LinkDescription = "Valheims website", Link = "https://www.valheimgame.com/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 6, LinkDescription = "WoW wiki", Link = "https://wowpedia.fandom.com/wiki/Wowpedia" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 7, LinkDescription = "Interior design", Link = "https://interiordesign.net/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 8, LinkDescription = "Dezeen interior design", Link = "https://www.dezeen.com/interiors/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 9, LinkDescription = "Carpenter Website Design Examples", Link = "https://www.webfactory.co.uk/portfolio-sectors?i=19&c=Carpenter" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 10, LinkDescription = "Elle", Link = "https://www.elle.se/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 11, LinkDescription = "Vogue", Link = "https://www.vogue.com/" });
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteId = 12, LinkDescription = "CS:GO Stash", Link = "https://csgostash.com/" });

            // Seed PersonInterestLink
            // Elin Hundar
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 1, PersonId = 1, InterestId = 2, WebsiteId = 2 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 2, PersonId = 1, InterestId = 2, WebsiteId = 3 });
            // Göran Innebandy
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 3, PersonId = 2, InterestId = 1, WebsiteId = 1 });
            // Klas Valheim
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 4, PersonId = 3, InterestId = 3, WebsiteId = 4 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 5, PersonId = 3, InterestId = 3, WebsiteId = 5 });
            // Siv WoW
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 6, PersonId = 4, InterestId = 4, WebsiteId = 6 });
            // Peter Interior Design
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 7, PersonId = 5, InterestId = 5, WebsiteId = 7 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 8, PersonId = 5, InterestId = 5, WebsiteId = 8 });
            // Amanda Carpenter
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 9, PersonId = 6, InterestId = 6, WebsiteId = 9 });
            // Siv Fashion
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 10, PersonId = 4, InterestId = 7, WebsiteId = 10 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 11, PersonId = 4, InterestId = 7, WebsiteId = 11 });
            // Göran CS
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { Id = 12, PersonId = 2, InterestId = 8, WebsiteId = 12 });
        }
    }
}
