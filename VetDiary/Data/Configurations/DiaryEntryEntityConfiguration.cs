using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class DiaryEntryEntityConfiguration : IEntityTypeConfiguration<DiaryEntry>
    {
        public void Configure(EntityTypeBuilder<DiaryEntry> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Pet)
                   .WithMany(p => p.DiaryEntries)
                   .HasForeignKey(d => d.PetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.VisitReason)
                   .WithMany(v => v.DiaryEntries)
                   .HasForeignKey(d => d.VisitReasonId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
