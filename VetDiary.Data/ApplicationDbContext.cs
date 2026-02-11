using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetDiary.Data.Models;

namespace VetDiary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }
        public DbSet<Client> Clients {  get; set; }

        public DbSet<Species> Species { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<VisitReason> VisitReasons { get; set; }
        
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }       

}
