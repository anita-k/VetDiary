using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class SpeciesEntityConfiguration : IEntityTypeConfiguration<Species>
    {
        public ICollection<Species> Species { get; private set; } = new List<Species> {
            new Species { Id = 1, Name = "Dog" },
            new Species { Id = 2, Name = "Cat" },
            new Species { Id = 3, Name = "Rabbit" },
            new Species { Id = 4, Name = "Hamster" },
            new Species { Id = 5, Name = "Guinea Pig" },
            new Species { Id = 6, Name = "Parrot" },
            new Species { Id = 7, Name = "Ferret" },
            new Species { Id = 8, Name = "Canary" },
            new Species { Id = 9, Name = "Turtle" },
            new Species { Id = 10, Name = "Snake" },
            new Species { Id = 11, Name = "Lizard" },
            new Species { Id = 12, Name = "Snake" },
            new Species { Id = 13, Name = "Horse" },
            new Species { Id = 14, Name = "Donkey" },
            new Species { Id = 15, Name = "Sheep" },
            new Species { Id = 16, Name = "Goat" },
            new Species { Id = 17, Name = "Pony" },
            new Species { Id = 18, Name = "Pig" },
            new Species { Id = 19, Name = "Chicken" },
            new Species { Id = 20, Name = "Turkey" },
            new Species { Id = 21, Name = "Fish" },
            new Species { Id = 22, Name = "Chinchilla" },
            new Species { Id = 23, Name = "Other Mammal" },
            new Species { Id = 24, Name = "Other Bird" },
            new Species { Id = 25, Name = "Other Reptile" },
            new Species { Id = 26, Name = "Other Exotic" },            
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasData(Species);
        }

    }
}


