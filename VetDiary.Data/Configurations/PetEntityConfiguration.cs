using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;
using VetDiary.Shared;

namespace VetDiary.Data.Configurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
        public ICollection<Pet> Pets { get; private set; } = new List<Pet>
        {
            // Client 1 - 2 pets
            new Pet { Id = 1, Name = "Buddy", Gender = PetGender.Male, BirthDate = new DateOnly(2020, 3, 15), ClientId = 1, SpeciesId = 1, BreedId = 2, MicrochipNumber = 100001 },
            new Pet { Id = 2, Name = "Whiskers", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 7, 22), ClientId = 1, SpeciesId = 2, BreedId = 33 },

            // Client 2 - 3 pets
            new Pet { Id = 3, Name = "Max", Gender = PetGender.Male, BirthDate = new DateOnly(2019, 1, 10), ClientId = 2, SpeciesId = 1, BreedId = 3, MicrochipNumber = 100002 },
            new Pet { Id = 4, Name = "Luna", Gender = PetGender.Female, BirthDate = new DateOnly(2022, 5, 8), ClientId = 2, SpeciesId = 2, BreedId = 36 },
            new Pet { Id = 5, Name = "Charlie", Gender = PetGender.Male, BirthDate = new DateOnly(2021, 11, 3), ClientId = 2, SpeciesId = 1, BreedId = 4, MicrochipNumber = 100003 },

            // Client 3 - 2 pets
            new Pet { Id = 6, Name = "Daisy", Gender = PetGender.Female, BirthDate = new DateOnly(2020, 9, 14), ClientId = 3, SpeciesId = 1, BreedId = 5 },
            new Pet { Id = 7, Name = "Coco", Gender = PetGender.Female, BirthDate = new DateOnly(2023, 2, 28), ClientId = 3, SpeciesId = 2, BreedId = 37 },

            // Client 4 - 1 pet
            new Pet { Id = 8, Name = "Rocky", Gender = PetGender.Male, BirthDate = new DateOnly(2018, 6, 20), ClientId = 4, SpeciesId = 1, BreedId = 10, MicrochipNumber = 100004 },

            // Client 5 - 2 pets
            new Pet { Id = 9, Name = "Bella", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 4, 5), ClientId = 5, SpeciesId = 1, BreedId = 7 },
            new Pet { Id = 10, Name = "Milo", Gender = PetGender.Male, BirthDate = new DateOnly(2022, 8, 17), ClientId = 5, SpeciesId = 2, BreedId = 41 },

            // Client 6 - 1 pet
            new Pet { Id = 11, Name = "Rosie", Gender = PetGender.Female, BirthDate = new DateOnly(2020, 12, 1), ClientId = 6, SpeciesId = 2, BreedId = 34 },

            // Client 7 - 3 pets
            new Pet { Id = 12, Name = "Oscar", Gender = PetGender.Male, BirthDate = new DateOnly(2019, 10, 25), ClientId = 7, SpeciesId = 1, BreedId = 14, MicrochipNumber = 100005 },
            new Pet { Id = 13, Name = "Nala", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 6, 13), ClientId = 7, SpeciesId = 2, BreedId = 35 },
            new Pet { Id = 14, Name = "Thumper", Gender = PetGender.Male, BirthDate = new DateOnly(2023, 1, 7), ClientId = 7, SpeciesId = 3 },

            // Client 8 - 5 pets
            new Pet { Id = 15, Name = "Duke", Gender = PetGender.Male, BirthDate = new DateOnly(2017, 5, 30), ClientId = 8, SpeciesId = 1, BreedId = 15, MicrochipNumber = 100006 },
            new Pet { Id = 16, Name = "Poppy", Gender = PetGender.Female, BirthDate = new DateOnly(2020, 3, 18), ClientId = 8, SpeciesId = 2, BreedId = 31 },
            new Pet { Id = 17, Name = "Rex", Gender = PetGender.Male, BirthDate = new DateOnly(2021, 9, 22), ClientId = 8, SpeciesId = 1, BreedId = 16, MicrochipNumber = 100007 },
            new Pet { Id = 18, Name = "Ziggy", Gender = PetGender.Male, BirthDate = new DateOnly(2022, 7, 4), ClientId = 8, SpeciesId = 6 },
            new Pet { Id = 19, Name = "Cleo", Gender = PetGender.Female, BirthDate = new DateOnly(2023, 4, 11), ClientId = 8, SpeciesId = 2, BreedId = 44 },

            // Client 9 - 1 pet
            new Pet { Id = 20, Name = "Cooper", Gender = PetGender.Male, BirthDate = new DateOnly(2020, 8, 9), ClientId = 9, SpeciesId = 1, BreedId = 20, MicrochipNumber = 100008 },

            // Client 10 - 3 pets
            new Pet { Id = 21, Name = "Sadie", Gender = PetGender.Female, BirthDate = new DateOnly(2019, 2, 14), ClientId = 10, SpeciesId = 1, BreedId = 22 },
            new Pet { Id = 22, Name = "Simba", Gender = PetGender.Male, BirthDate = new DateOnly(2021, 12, 6), ClientId = 10, SpeciesId = 2, BreedId = 41 },
            new Pet { Id = 23, Name = "Peanut", Gender = PetGender.Male, BirthDate = new DateOnly(2023, 3, 20), ClientId = 10, SpeciesId = 4 },

            // Client 11 - 2 pets
            new Pet { Id = 24, Name = "Tucker", Gender = PetGender.Male, BirthDate = new DateOnly(2020, 6, 15), ClientId = 11, SpeciesId = 1, BreedId = 8, MicrochipNumber = 100009 },
            new Pet { Id = 25, Name = "Molly", Gender = PetGender.Female, BirthDate = new DateOnly(2022, 1, 28), ClientId = 11, SpeciesId = 1, BreedId = 21 },

            // Client 12 - 4 pets
            new Pet { Id = 26, Name = "Shadow", Gender = PetGender.Male, BirthDate = new DateOnly(2018, 11, 3), ClientId = 12, SpeciesId = 2, BreedId = 46 },
            new Pet { Id = 27, Name = "Ginger", Gender = PetGender.Female, BirthDate = new DateOnly(2020, 4, 22), ClientId = 12, SpeciesId = 2, BreedId = 32 },
            new Pet { Id = 28, Name = "Bruno", Gender = PetGender.Male, BirthDate = new DateOnly(2021, 8, 7), ClientId = 12, SpeciesId = 1, BreedId = 12, MicrochipNumber = 100010 },
            new Pet { Id = 29, Name = "Shelly", Gender = PetGender.Female, BirthDate = new DateOnly(2022, 10, 15), ClientId = 12, SpeciesId = 9 },

            // Client 13 - 1 pet
            new Pet { Id = 30, Name = "Zeus", Gender = PetGender.Male, BirthDate = new DateOnly(2019, 7, 19), ClientId = 13, SpeciesId = 1, BreedId = 23, MicrochipNumber = 100011 },

            // Client 14 - 2 pets
            new Pet { Id = 31, Name = "Lola", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 5, 10), ClientId = 14, SpeciesId = 1, BreedId = 19 },
            new Pet { Id = 32, Name = "Oliver", Gender = PetGender.Male, BirthDate = new DateOnly(2022, 9, 3), ClientId = 14, SpeciesId = 2, BreedId = 38 },

            // Client 15 - 1 pet
            new Pet { Id = 33, Name = "Teddy", Gender = PetGender.Male, BirthDate = new DateOnly(2020, 11, 25), ClientId = 15, SpeciesId = 1, BreedId = 17, MicrochipNumber = 100012 },

            // Client 16 - 3 pets
            new Pet { Id = 34, Name = "Ruby", Gender = PetGender.Female, BirthDate = new DateOnly(2019, 3, 8), ClientId = 16, SpeciesId = 1, BreedId = 6 },
            new Pet { Id = 35, Name = "Leo", Gender = PetGender.Male, BirthDate = new DateOnly(2021, 10, 14), ClientId = 16, SpeciesId = 2, BreedId = 43 },
            new Pet { Id = 36, Name = "Biscuit", Gender = PetGender.Male, BirthDate = new DateOnly(2023, 6, 1), ClientId = 16, SpeciesId = 3 },

            // Client 17 - 1 pet
            new Pet { Id = 37, Name = "Finn", Gender = PetGender.Male, BirthDate = new DateOnly(2020, 2, 17), ClientId = 17, SpeciesId = 1, BreedId = 9, MicrochipNumber = 100013 },

            // Client 18 - 2 pets
            new Pet { Id = 38, Name = "Willow", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 7, 30), ClientId = 18, SpeciesId = 2, BreedId = 39 },
            new Pet { Id = 39, Name = "Archie", Gender = PetGender.Male, BirthDate = new DateOnly(2022, 12, 5), ClientId = 18, SpeciesId = 1, BreedId = 25 },

            // Client 19 - 1 pet
            new Pet { Id = 40, Name = "Pepper", Gender = PetGender.Female, BirthDate = new DateOnly(2020, 10, 8), ClientId = 19, SpeciesId = 1, BreedId = 13, MicrochipNumber = 100014 },

            // Client 20 - 3 pets
            new Pet { Id = 41, Name = "Bear", Gender = PetGender.Male, BirthDate = new DateOnly(2019, 9, 12), ClientId = 20, SpeciesId = 1, BreedId = 29, MicrochipNumber = 100015 },
            new Pet { Id = 42, Name = "Mittens", Gender = PetGender.Female, BirthDate = new DateOnly(2021, 3, 26), ClientId = 20, SpeciesId = 2, BreedId = 40 },
            new Pet { Id = 43, Name = "Hazel", Gender = PetGender.Female, BirthDate = new DateOnly(2023, 5, 18), ClientId = 20, SpeciesId = 4 },
        };

        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Client)
                   .WithMany(c => c.Pets)
                   .HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Species)
                   .WithMany(s => s.Pets)
                   .HasForeignKey(p => p.SpeciesId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Breed)
                   .WithMany(s => s.Pets)
                   .HasForeignKey(p => p.BreedId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Pets);
        }
    }
}
