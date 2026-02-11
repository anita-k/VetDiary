using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<Breed>
    {
        public ICollection<Breed> Breeds { get; private set; } = new List<Breed> {
            new Breed { Id = 1, SpeciesId = 1, Name = "Mixed Breed" },
            new Breed { Id = 2, SpeciesId = 1, Name = "Labrador Retriever" },
            new Breed { Id = 3, SpeciesId = 1, Name = "German Shepherd" },
            new Breed { Id = 4, SpeciesId = 1, Name = "Golden Retriever" },
            new Breed { Id = 5, SpeciesId = 1, Name = "French Bulldog" },
            new Breed { Id = 6, SpeciesId = 1, Name = "Cavalier King Charles Spaniel" },
            new Breed { Id = 7, SpeciesId = 1, Name = "Poodle" },
            new Breed { Id = 8, SpeciesId = 1, Name = "Jack Russell Terrier" },
            new Breed { Id = 9, SpeciesId = 1, Name = "Corgi" },
            new Breed { Id = 10, SpeciesId = 1, Name = "Rottweiler" },
            new Breed { Id = 11, SpeciesId = 1, Name = "Yorkshire Terrier" },
            new Breed { Id = 12, SpeciesId = 1, Name = "Boxer" },
            new Breed { Id = 13, SpeciesId = 1, Name = "Dachshund" },
            new Breed { Id = 14, SpeciesId = 1, Name = "Beagle" },
            new Breed { Id = 15, SpeciesId = 1, Name = "Siberian Husky" },
            new Breed { Id = 16, SpeciesId = 1, Name = "Doberman Pinscher" },
            new Breed { Id = 17, SpeciesId = 1, Name = "Shih Tzu" },
            new Breed { Id = 18, SpeciesId = 1, Name = "Chihuahua" },
            new Breed { Id = 19, SpeciesId = 1, Name = "Pomeranian" },
            new Breed { Id = 20, SpeciesId = 1, Name = "Border Collie" },
            new Breed { Id = 21, SpeciesId = 1, Name = "Cocker Spaniel" },
            new Breed { Id = 22, SpeciesId = 1, Name = "Australian Shepherd" },
            new Breed { Id = 23, SpeciesId = 1, Name = "Great Dane" },
            new Breed { Id = 24, SpeciesId = 1, Name = "Maltese" },
            new Breed { Id = 25, SpeciesId = 1, Name = "Boston Terrier" },
            new Breed { Id = 26, SpeciesId = 1, Name = "Cane Corso" },
            new Breed { Id = 27, SpeciesId = 1, Name = "Akita" },
            new Breed { Id = 28, SpeciesId = 1, Name = "Saint Bernard" },
            new Breed { Id = 29, SpeciesId = 1, Name = "Bernese Mountain Dog" },
            new Breed { Id = 30, SpeciesId = 1, Name = "Other / Unknown" },
            new Breed { Id = 31, SpeciesId = 2, Name = "Domestic Shorthair" },
            new Breed { Id = 32, SpeciesId = 2, Name = "Domestic Longhair" },
            new Breed { Id = 33, SpeciesId = 2, Name = "Maine Coon" },
            new Breed { Id = 34, SpeciesId = 2, Name = "Persian" },
            new Breed { Id = 35, SpeciesId = 2, Name = "Siamese" },
            new Breed { Id = 36, SpeciesId = 2, Name = "Ragdoll" },
            new Breed { Id = 37, SpeciesId = 2, Name = "British Shorthair" },
            new Breed { Id = 38, SpeciesId = 2, Name = "Siberian" },
            new Breed { Id = 39, SpeciesId = 2, Name = "Norwegian Forest Cat" },
            new Breed { Id = 40, SpeciesId = 2, Name = "Birman" },
            new Breed { Id = 41, SpeciesId = 2, Name = "Bengal" },
            new Breed { Id = 42, SpeciesId = 2, Name = "Abyssinian" },
            new Breed { Id = 43, SpeciesId = 2, Name = "Scottish Fold" },
            new Breed { Id = 44, SpeciesId = 2, Name = "Sphynx" },
            new Breed { Id = 45, SpeciesId = 2, Name = "Burmese" },
            new Breed { Id = 46, SpeciesId = 2, Name = "Russian Blue" },
            new Breed { Id = 47, SpeciesId = 2, Name = "American Shorthair" },
            new Breed { Id = 48, SpeciesId = 2, Name = "Oriental Shorthair" },
            new Breed { Id = 49, SpeciesId = 2, Name = "Devon Rex" },
            new Breed { Id = 50, SpeciesId = 2, Name = "Mixed Breed" },
            new Breed { Id = 51, SpeciesId = 13, Name = "Other / Unknown" },
            new Breed { Id = 52, SpeciesId = 13, Name = "Arabian" },
            new Breed { Id = 53, SpeciesId = 13, Name = "Andalusian" },
            new Breed { Id = 54, SpeciesId = 13, Name = "American Quarter Horse" },
            new Breed { Id = 55, SpeciesId = 13, Name = "Friesian" },
            new Breed { Id = 56, SpeciesId = 13, Name = "Thoroughbred" },
            new Breed { Id = 57, SpeciesId = 13, Name = "Appaloosa" },
            new Breed { Id = 58, SpeciesId = 13, Name = "Morgan" },
            new Breed { Id = 59, SpeciesId = 13, Name = "Clydesdale" },
            new Breed { Id = 60, SpeciesId = 13, Name = "Shire" },
            new Breed { Id = 61, SpeciesId = 13, Name = "Orlov Trotter" },
            new Breed { Id = 62, SpeciesId = 13, Name = "Hackney" },
            };


        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.HasOne(b => b.Species)
                   .WithMany(s => s.Breeds)
                   .HasForeignKey(b => b.SpeciesId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Breeds);

        }

    }
}


