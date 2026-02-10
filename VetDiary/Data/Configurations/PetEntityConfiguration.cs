using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
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
        }
    }
}
