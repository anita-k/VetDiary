using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public ICollection<Client> Clients { get; private set; } = new List<Client>
        {
            new Client { Id = 1, FirstName = "John", LastName = "Smith", Phone = "+44 20 7946 0958", Email = "john.smith@email.com", Address = "12 Baker Street, London" },
            new Client { Id = 2, FirstName = "Emma", LastName = "Wilson", Phone = "+1 212 555 0147", Email = "emma.wilson@email.com", Address = "450 Park Avenue, New York" },
            new Client { Id = 3, FirstName = "James", LastName = "Brown", Phone = "+61 2 9374 4000", Email = "james.brown@email.com", Address = "88 George Street, Sydney" },
            new Client { Id = 4, FirstName = "Olivia", LastName = "Taylor", Phone = "+1 310 555 0198", Email = "olivia.taylor@email.com", Address = "1200 Sunset Blvd, Los Angeles" },
            new Client { Id = 5, FirstName = "William", LastName = "Davis", Phone = "+44 161 555 0123", Email = "william.davis@email.com", Address = "34 Deansgate, Manchester" },
            new Client { Id = 6, FirstName = "Sophia", LastName = "Johnson", Phone = "+1 416 555 0176", Email = "sophia.johnson@email.com", Address = "200 Bay Street, Toronto" },
            new Client { Id = 7, FirstName = "Benjamin", LastName = "Miller", Phone = "+1 312 555 0134", Email = "benjamin.miller@email.com", Address = "500 Michigan Ave, Chicago" },
            new Client { Id = 8, FirstName = "Charlotte", LastName = "Anderson", Phone = "+64 9 555 0145", Email = "charlotte.anderson@email.com", Address = "15 Queen Street, Auckland" },
            new Client { Id = 9, FirstName = "Henry", LastName = "Thomas", Phone = "+44 131 555 0189", Email = "henry.thomas@email.com", Address = "22 Princes Street, Edinburgh" },
            new Client { Id = 10, FirstName = "Amelia", LastName = "Jackson", Phone = "+1 604 555 0156", Email = "amelia.jackson@email.com", Address = "800 Robson Street, Vancouver" },
            new Client { Id = 11, FirstName = "Alexander", LastName = "White", Phone = "+1 617 555 0167", Email = "alexander.white@email.com", Address = "100 Beacon Street, Boston" },
            new Client { Id = 12, FirstName = "Isabella", LastName = "Harris", Phone = "+44 117 555 0112", Email = "isabella.harris@email.com", Address = "5 Park Row, Bristol" },
            new Client { Id = 13, FirstName = "Daniel", LastName = "Martin", Phone = "+61 3 9555 0178", Email = "daniel.martin@email.com", Address = "250 Collins Street, Melbourne" },
            new Client { Id = 14, FirstName = "Mia", LastName = "Thompson", Phone = "+1 415 555 0189", Email = "mia.thompson@email.com", Address = "600 Market Street, San Francisco" },
            new Client { Id = 15, FirstName = "Matthew", LastName = "Garcia", Phone = "+1 305 555 0145", Email = "matthew.garcia@email.com", Address = "300 Brickell Ave, Miami" },
            new Client { Id = 16, FirstName = "Harper", LastName = "Martinez", Phone = "+44 113 555 0134", Email = "harper.martinez@email.com", Address = "18 The Headrow, Leeds" },
            new Client { Id = 17, FirstName = "Ethan", LastName = "Robinson", Phone = "+1 206 555 0156", Email = "ethan.robinson@email.com", Address = "400 Pike Street, Seattle" },
            new Client { Id = 18, FirstName = "Evelyn", LastName = "Clark", Phone = "+61 7 3555 0167", Email = "evelyn.clark@email.com", Address = "120 Adelaide Street, Brisbane" },
            new Client { Id = 19, FirstName = "Sebastian", LastName = "Lewis", Phone = "+1 512 555 0178", Email = "sebastian.lewis@email.com", Address = "700 Congress Ave, Austin" },
            new Client { Id = 20, FirstName = "Abigail", LastName = "Walker", Phone = "+44 121 555 0189", Email = "abigail.walker@email.com", Address = "42 New Street, Birmingham" },
        };

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData(Clients);
        }
    }
}
