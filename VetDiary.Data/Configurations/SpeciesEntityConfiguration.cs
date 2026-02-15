using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class SpeciesEntityConfiguration : IEntityTypeConfiguration<Species>
    {
        public ICollection<Species> Species { get; private set; } = new List<Species> {
            new Species { Id = 1, Name = "Dog", Icon = "🐶"},
            new Species { Id = 2, Name = "Cat", Icon = "🐱" },
            new Species { Id = 3, Name = "Rabbit", Icon = "🐰" },
            new Species { Id = 4, Name = "Hamster", Icon = "🐹" },
            new Species { Id = 5, Name = "Guinea Pig", Icon = "🐹" },
            new Species { Id = 6, Name = "Parrot", Icon = "🦜" },
            new Species { Id = 7, Name = "Ferret", Icon = "🦦" },
            new Species { Id = 8, Name = "Canary", Icon = "🐦" },
            new Species { Id = 9, Name = "Turtle", Icon = "🐢" },
            new Species { Id = 10, Name = "Snake", Icon = "🐍" },
            new Species { Id = 11, Name = "Lizard", Icon = "🦎" },
            new Species { Id = 12, Name = "Frog", Icon = "🐸" },
            new Species { Id = 13, Name = "Horse", Icon = "🐴" },
            new Species { Id = 14, Name = "Donkey", Icon = "🐎" },
            new Species { Id = 15, Name = "Sheep", Icon = "🐑" },
            new Species { Id = 16, Name = "Goat", Icon = "🐐" },
            new Species { Id = 17, Name = "Pony", Icon = "🐎" },
            new Species { Id = 18, Name = "Pig", Icon = "🐷" },
            new Species { Id = 19, Name = "Chicken", Icon = "🐤" },
            new Species { Id = 20, Name = "Turkey", Icon = "🦃" },
            new Species { Id = 21, Name = "Fish", Icon = "🐟" },
            new Species { Id = 22, Name = "Chinchilla", Icon = "🐭" },
            new Species { Id = 23, Name = "Other Mammal", Icon = "🐾" },
            new Species { Id = 24, Name = "Other Bird", Icon = "🕊️" },
            new Species { Id = 25, Name = "Other Reptile", Icon = "🐲" },
            new Species { Id = 26, Name = "Other Exotic", Icon = "🦄" },
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasData(Species);
        }

    }
}


