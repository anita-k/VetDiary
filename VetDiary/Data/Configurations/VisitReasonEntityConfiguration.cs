using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class VisitReasonEntityConfiguration : IEntityTypeConfiguration<VisitReason>
    {
        public ICollection<VisitReason> VisitReasons { get; private set; } = new List<VisitReason> {
            new VisitReason { Id = 1, Name = "General Checkup" },
            new VisitReason { Id = 2, Name = "Illness" },
            new VisitReason { Id = 3, Name = "Vaccination" },
            new VisitReason { Id = 4, Name = "Surgery" },
            new VisitReason { Id = 5, Name = "Injury" },
            new VisitReason { Id = 6, Name = "Dental Care" },
            new VisitReason { Id = 7, Name = "Parasite Treatment" },
            new VisitReason { Id = 8, Name = "Emergency" },
            new VisitReason { Id = 9, Name = "Follow Up" },
            new VisitReason { Id = 10, Name = "Other" },
        };

        public void Configure(EntityTypeBuilder<VisitReason> builder)
        {
            builder.HasData(VisitReasons);
        }              

    }
}
