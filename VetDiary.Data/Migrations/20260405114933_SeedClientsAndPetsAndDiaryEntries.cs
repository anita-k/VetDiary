using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetDiary.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedClientsAndPetsAndDiaryEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "12 Baker Street, London", "john.smith@email.com", "John", "Smith", "+44 20 7946 0958" },
                    { 2, "450 Park Avenue, New York", "emma.wilson@email.com", "Emma", "Wilson", "+1 212 555 0147" },
                    { 3, "88 George Street, Sydney", "james.brown@email.com", "James", "Brown", "+61 2 9374 4000" },
                    { 4, "1200 Sunset Blvd, Los Angeles", "olivia.taylor@email.com", "Olivia", "Taylor", "+1 310 555 0198" },
                    { 5, "34 Deansgate, Manchester", "william.davis@email.com", "William", "Davis", "+44 161 555 0123" },
                    { 6, "200 Bay Street, Toronto", "sophia.johnson@email.com", "Sophia", "Johnson", "+1 416 555 0176" },
                    { 7, "500 Michigan Ave, Chicago", "benjamin.miller@email.com", "Benjamin", "Miller", "+1 312 555 0134" },
                    { 8, "15 Queen Street, Auckland", "charlotte.anderson@email.com", "Charlotte", "Anderson", "+64 9 555 0145" },
                    { 9, "22 Princes Street, Edinburgh", "henry.thomas@email.com", "Henry", "Thomas", "+44 131 555 0189" },
                    { 10, "800 Robson Street, Vancouver", "amelia.jackson@email.com", "Amelia", "Jackson", "+1 604 555 0156" },
                    { 11, "100 Beacon Street, Boston", "alexander.white@email.com", "Alexander", "White", "+1 617 555 0167" },
                    { 12, "5 Park Row, Bristol", "isabella.harris@email.com", "Isabella", "Harris", "+44 117 555 0112" },
                    { 13, "250 Collins Street, Melbourne", "daniel.martin@email.com", "Daniel", "Martin", "+61 3 9555 0178" },
                    { 14, "600 Market Street, San Francisco", "mia.thompson@email.com", "Mia", "Thompson", "+1 415 555 0189" },
                    { 15, "300 Brickell Ave, Miami", "matthew.garcia@email.com", "Matthew", "Garcia", "+1 305 555 0145" },
                    { 16, "18 The Headrow, Leeds", "harper.martinez@email.com", "Harper", "Martinez", "+44 113 555 0134" },
                    { 17, "400 Pike Street, Seattle", "ethan.robinson@email.com", "Ethan", "Robinson", "+1 206 555 0156" },
                    { 18, "120 Adelaide Street, Brisbane", "evelyn.clark@email.com", "Evelyn", "Clark", "+61 7 3555 0167" },
                    { 19, "700 Congress Ave, Austin", "sebastian.lewis@email.com", "Sebastian", "Lewis", "+1 512 555 0178" },
                    { 20, "42 New Street, Birmingham", "abigail.walker@email.com", "Abigail", "Walker", "+44 121 555 0189" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "BreedId", "ClientId", "Gender", "IsNeutered", "MicrochipNumber", "Name", "PassportNumber", "SpeciesId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2020, 3, 15), 2, 1, 0, null, 100001, "Buddy", "", 1 },
                    { 2, new DateOnly(2021, 7, 22), 33, 1, 1, null, null, "Whiskers", "", 2 },
                    { 3, new DateOnly(2019, 1, 10), 3, 2, 0, null, 100002, "Max", "", 1 },
                    { 4, new DateOnly(2022, 5, 8), 36, 2, 1, null, null, "Luna", "", 2 },
                    { 5, new DateOnly(2021, 11, 3), 4, 2, 0, null, 100003, "Charlie", "", 1 },
                    { 6, new DateOnly(2020, 9, 14), 5, 3, 1, null, null, "Daisy", "", 1 },
                    { 7, new DateOnly(2023, 2, 28), 37, 3, 1, null, null, "Coco", "", 2 },
                    { 8, new DateOnly(2018, 6, 20), 10, 4, 0, null, 100004, "Rocky", "", 1 },
                    { 9, new DateOnly(2021, 4, 5), 7, 5, 1, null, null, "Bella", "", 1 },
                    { 10, new DateOnly(2022, 8, 17), 41, 5, 0, null, null, "Milo", "", 2 },
                    { 11, new DateOnly(2020, 12, 1), 34, 6, 1, null, null, "Rosie", "", 2 },
                    { 12, new DateOnly(2019, 10, 25), 14, 7, 0, null, 100005, "Oscar", "", 1 },
                    { 13, new DateOnly(2021, 6, 13), 35, 7, 1, null, null, "Nala", "", 2 },
                    { 14, new DateOnly(2023, 1, 7), null, 7, 0, null, null, "Thumper", "", 3 },
                    { 15, new DateOnly(2017, 5, 30), 15, 8, 0, null, 100006, "Duke", "", 1 },
                    { 16, new DateOnly(2020, 3, 18), 31, 8, 1, null, null, "Poppy", "", 2 },
                    { 17, new DateOnly(2021, 9, 22), 16, 8, 0, null, 100007, "Rex", "", 1 },
                    { 18, new DateOnly(2022, 7, 4), null, 8, 0, null, null, "Ziggy", "", 6 },
                    { 19, new DateOnly(2023, 4, 11), 44, 8, 1, null, null, "Cleo", "", 2 },
                    { 20, new DateOnly(2020, 8, 9), 20, 9, 0, null, 100008, "Cooper", "", 1 },
                    { 21, new DateOnly(2019, 2, 14), 22, 10, 1, null, null, "Sadie", "", 1 },
                    { 22, new DateOnly(2021, 12, 6), 41, 10, 0, null, null, "Simba", "", 2 },
                    { 23, new DateOnly(2023, 3, 20), null, 10, 0, null, null, "Peanut", "", 4 },
                    { 24, new DateOnly(2020, 6, 15), 8, 11, 0, null, 100009, "Tucker", "", 1 },
                    { 25, new DateOnly(2022, 1, 28), 21, 11, 1, null, null, "Molly", "", 1 },
                    { 26, new DateOnly(2018, 11, 3), 46, 12, 0, null, null, "Shadow", "", 2 },
                    { 27, new DateOnly(2020, 4, 22), 32, 12, 1, null, null, "Ginger", "", 2 },
                    { 28, new DateOnly(2021, 8, 7), 12, 12, 0, null, 100010, "Bruno", "", 1 },
                    { 29, new DateOnly(2022, 10, 15), null, 12, 1, null, null, "Shelly", "", 9 },
                    { 30, new DateOnly(2019, 7, 19), 23, 13, 0, null, 100011, "Zeus", "", 1 },
                    { 31, new DateOnly(2021, 5, 10), 19, 14, 1, null, null, "Lola", "", 1 },
                    { 32, new DateOnly(2022, 9, 3), 38, 14, 0, null, null, "Oliver", "", 2 },
                    { 33, new DateOnly(2020, 11, 25), 17, 15, 0, null, 100012, "Teddy", "", 1 },
                    { 34, new DateOnly(2019, 3, 8), 6, 16, 1, null, null, "Ruby", "", 1 },
                    { 35, new DateOnly(2021, 10, 14), 43, 16, 0, null, null, "Leo", "", 2 },
                    { 36, new DateOnly(2023, 6, 1), null, 16, 0, null, null, "Biscuit", "", 3 },
                    { 37, new DateOnly(2020, 2, 17), 9, 17, 0, null, 100013, "Finn", "", 1 },
                    { 38, new DateOnly(2021, 7, 30), 39, 18, 1, null, null, "Willow", "", 2 },
                    { 39, new DateOnly(2022, 12, 5), 25, 18, 0, null, null, "Archie", "", 1 },
                    { 40, new DateOnly(2020, 10, 8), 13, 19, 1, null, 100014, "Pepper", "", 1 },
                    { 41, new DateOnly(2019, 9, 12), 29, 20, 0, null, 100015, "Bear", "", 1 },
                    { 42, new DateOnly(2021, 3, 26), 40, 20, 1, null, null, "Mittens", "", 2 },
                    { 43, new DateOnly(2023, 5, 18), null, 20, 1, null, null, "Hazel", "", 4 }
                });

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Behaviour", "BodyConditionScore", "Description", "PetId", "Pulse", "Temperature", "VisitDate", "VisitReasonId", "Weight" },
                values: new object[,]
                {
                    { 1, null, 5, "Annual checkup, all vitals normal", 1, 90, 38.5f, new DateTime(2025, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 28.5f },
                    { 2, null, null, "Rabies vaccination booster", 1, null, 38.6f, new DateTime(2025, 4, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, 29f },
                    { 3, null, null, "Flea and tick preventive treatment", 1, null, null, new DateTime(2025, 9, 20, 11, 15, 0, 0, DateTimeKind.Unspecified), 7, 28.8f },
                    { 4, null, 5, "Routine exam, healthy coat", 2, 160, 38.8f, new DateTime(2025, 2, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 4.2f },
                    { 5, null, null, "Dental cleaning, minor tartar removed", 2, null, null, new DateTime(2025, 8, 12, 15, 45, 0, 0, DateTimeKind.Unspecified), 6, 4.3f },
                    { 6, null, 6, "Annual wellness check", 3, 85, 38.4f, new DateTime(2025, 1, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 34f },
                    { 7, "Scratching ears frequently", null, "Mild ear infection, prescribed antibiotics", 3, null, 39.1f, new DateTime(2025, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 33.8f },
                    { 8, null, null, "Follow-up on ear infection, resolved", 3, null, 38.5f, new DateTime(2025, 4, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), 9, 34.1f },
                    { 9, null, null, "Annual vaccinations updated", 3, null, null, new DateTime(2025, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 34.5f },
                    { 10, null, null, "Core vaccinations", 4, null, 38.7f, new DateTime(2025, 2, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 3.8f },
                    { 11, null, 5, "Six-month checkup, gaining weight well", 4, null, 38.9f, new DateTime(2025, 6, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 4.1f },
                    { 12, null, null, "Deworming treatment", 4, null, null, new DateTime(2025, 11, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 7, 4.4f },
                    { 13, null, 5, "General health check, excellent condition", 5, 88, 38.5f, new DateTime(2025, 3, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 30.2f },
                    { 14, null, null, "Booster vaccinations", 5, null, null, new DateTime(2025, 9, 8, 10, 45, 0, 0, DateTimeKind.Unspecified), 3, 31f },
                    { 15, "Excessive licking of paws", null, "Skin allergy, prescribed antihistamines", 6, null, 38.6f, new DateTime(2025, 1, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 11.5f },
                    { 16, null, null, "Allergy follow-up, symptoms improving", 6, null, null, new DateTime(2025, 2, 19, 9, 15, 0, 0, DateTimeKind.Unspecified), 9, 11.6f },
                    { 17, null, 5, "Routine checkup, allergy managed", 6, null, 38.5f, new DateTime(2025, 7, 14, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 11.8f },
                    { 18, null, null, "First vaccination series", 7, null, 38.8f, new DateTime(2025, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, 3f },
                    { 19, null, null, "Second vaccination dose", 7, null, 38.7f, new DateTime(2025, 5, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, 3.3f },
                    { 20, null, 6, "Senior wellness exam", 8, 80, 38.3f, new DateTime(2025, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 42f },
                    { 21, "Slight limping", null, "Minor limp on front right leg, X-ray clear", 8, null, null, new DateTime(2025, 3, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), 5, 41.8f },
                    { 22, null, null, "Dental extraction of cracked molar", 8, null, 38.4f, new DateTime(2025, 6, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), 6, 41.5f },
                    { 23, null, 5, "End-of-year checkup, good for his age", 8, null, 38.4f, new DateTime(2025, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 41f },
                    { 24, null, null, "Spay surgery, uneventful recovery", 9, null, 38.6f, new DateTime(2025, 2, 28, 8, 30, 0, 0, DateTimeKind.Unspecified), 4, 8.5f },
                    { 25, null, null, "Post-surgery checkup, sutures healing well", 9, null, null, new DateTime(2025, 3, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, 8.3f },
                    { 26, null, 5, "Routine exam, fully recovered", 9, null, 38.5f, new DateTime(2025, 8, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.8f },
                    { 27, null, null, "Kitten vaccinations", 10, null, 38.9f, new DateTime(2025, 5, 10, 9, 45, 0, 0, DateTimeKind.Unspecified), 3, 2.8f },
                    { 28, null, 5, "Annual checkup, active and healthy", 10, null, 38.7f, new DateTime(2025, 11, 18, 16, 15, 0, 0, DateTimeKind.Unspecified), 1, 4.5f },
                    { 29, null, 5, "Routine checkup, coat in good condition", 11, 155, 38.8f, new DateTime(2025, 1, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 3.9f },
                    { 30, "Lethargy, reduced appetite", null, "Vomiting episodes, dietary adjustment recommended", 11, null, 39f, new DateTime(2025, 5, 22, 14, 15, 0, 0, DateTimeKind.Unspecified), 2, 3.7f },
                    { 31, null, null, "Follow-up, eating normally again", 11, null, null, new DateTime(2025, 6, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 9, 3.8f },
                    { 32, null, 7, "Annual exam, slight weight gain noted", 12, 100, 38.5f, new DateTime(2025, 2, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 14f },
                    { 33, null, null, "Heartworm preventive treatment", 12, null, null, new DateTime(2025, 6, 15, 15, 30, 0, 0, DateTimeKind.Unspecified), 7, 13.5f },
                    { 34, null, 6, "Vaccination booster", 12, null, 38.5f, new DateTime(2025, 10, 28, 8, 45, 0, 0, DateTimeKind.Unspecified), 3, 13.2f },
                    { 35, null, null, "Spay surgery, smooth procedure", 13, null, 38.7f, new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, 3.6f },
                    { 36, null, null, "Post-op check, healing perfectly", 13, null, null, new DateTime(2025, 3, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 9, 3.5f },
                    { 37, null, null, "New patient exam, healthy rabbit", 14, null, 39.2f, new DateTime(2025, 2, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 2.1f },
                    { 38, null, null, "Dental check, teeth wearing evenly", 14, null, null, new DateTime(2025, 8, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, 2.4f },
                    { 39, "Stiffness after rest", 5, "Senior exam, mild arthritis noted", 15, 78, 38.3f, new DateTime(2025, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 27f },
                    { 40, null, null, "Joint pain management, started on supplements", 15, null, null, new DateTime(2025, 3, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, 26.8f },
                    { 41, null, null, "Arthritis follow-up, mobility improved", 15, null, null, new DateTime(2025, 5, 30, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 26.5f },
                    { 42, null, null, "Annual vaccinations", 15, null, 38.4f, new DateTime(2025, 8, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), 3, 26.7f },
                    { 43, null, 5, "Year-end wellness check, stable condition", 15, null, 38.3f, new DateTime(2025, 12, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 26.3f },
                    { 44, null, 5, "Routine checkup, good health", 16, null, 38.8f, new DateTime(2025, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 4f },
                    { 45, null, null, "Flea treatment applied", 16, null, null, new DateTime(2025, 7, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, 4.1f },
                    { 46, null, null, "Booster vaccinations", 16, null, null, new DateTime(2025, 11, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), 3, 4.2f },
                    { 47, null, 5, "First annual checkup", 17, 82, 38.5f, new DateTime(2025, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 35f },
                    { 48, "Limping slightly", null, "Minor cut on paw, cleaned and bandaged", 17, null, null, new DateTime(2025, 10, 3, 15, 15, 0, 0, DateTimeKind.Unspecified), 5, 36.2f },
                    { 49, null, null, "Wellness exam, feathers in good condition", 18, null, null, new DateTime(2025, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 0.35f },
                    { 50, null, null, "Wing clipping", 18, null, null, new DateTime(2025, 11, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 10, 0.36f },
                    { 51, null, null, "Kitten vaccination series", 19, null, 38.9f, new DateTime(2025, 6, 8, 8, 15, 0, 0, DateTimeKind.Unspecified), 3, 1.8f },
                    { 52, null, null, "Second dose vaccinations", 19, null, 38.8f, new DateTime(2025, 7, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 3, 2.2f },
                    { 53, null, 5, "Annual wellness check", 20, 92, 38.5f, new DateTime(2025, 1, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 22f },
                    { 54, null, null, "Vaccination booster", 20, null, null, new DateTime(2025, 5, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 22.3f },
                    { 55, "Reduced appetite", null, "Mild stomach upset, prescribed probiotics", 20, null, 38.8f, new DateTime(2025, 9, 30, 16, 45, 0, 0, DateTimeKind.Unspecified), 2, 22.1f },
                    { 56, null, 5, "Routine checkup, active and fit", 21, 88, 38.4f, new DateTime(2025, 2, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 20.5f },
                    { 57, null, null, "Tick prevention treatment", 21, null, null, new DateTime(2025, 6, 20, 13, 15, 0, 0, DateTimeKind.Unspecified), 7, 20.8f },
                    { 58, null, null, "Annual vaccinations", 21, null, null, new DateTime(2025, 11, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 3, 21f },
                    { 59, null, null, "Neuter surgery, routine", 22, null, 38.7f, new DateTime(2025, 3, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, 4.5f },
                    { 60, null, null, "Post-neuter check, all good", 22, null, null, new DateTime(2025, 3, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), 9, 4.4f },
                    { 61, null, null, "Initial health assessment, healthy hamster", 23, null, null, new DateTime(2025, 5, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 0.14f },
                    { 62, "Sneezing", null, "Runny nose, prescribed medication", 23, null, null, new DateTime(2025, 10, 22, 10, 45, 0, 0, DateTimeKind.Unspecified), 2, 0.15f },
                    { 63, null, 5, "Annual exam, energetic and healthy", 24, 110, 38.6f, new DateTime(2025, 1, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.5f },
                    { 64, null, null, "Torn nail, treated and bandaged", 24, null, null, new DateTime(2025, 4, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), 5, 7.6f },
                    { 65, null, null, "Vaccinations updated", 24, null, null, new DateTime(2025, 9, 12, 9, 15, 0, 0, DateTimeKind.Unspecified), 3, 7.8f },
                    { 66, null, null, "Puppy vaccinations", 25, null, 38.6f, new DateTime(2025, 3, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 10.2f },
                    { 67, null, 5, "Six-month checkup, growing well", 25, null, 38.5f, new DateTime(2025, 8, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 12.5f },
                    { 68, null, 4, "Senior cat exam, slight weight loss", 26, 150, 38.7f, new DateTime(2025, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 5.2f },
                    { 69, null, null, "Blood work ordered, thyroid levels checked", 26, null, null, new DateTime(2025, 2, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 5f },
                    { 70, null, null, "Results normal, dietary change recommended", 26, null, null, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 9, 5.1f },
                    { 71, null, 5, "Follow-up, weight stabilized", 26, null, 38.6f, new DateTime(2025, 9, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 5.3f },
                    { 72, null, 5, "Routine wellness check", 27, null, 38.8f, new DateTime(2025, 4, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 4.8f },
                    { 73, null, null, "Flea treatment", 27, null, null, new DateTime(2025, 10, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), 7, 4.9f },
                    { 74, null, 6, "Annual checkup, muscular build", 28, 85, 38.4f, new DateTime(2025, 2, 8, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 32f },
                    { 75, "Restless, drooling", null, "Emergency: ingested foreign object, induced vomiting", 28, null, 39.2f, new DateTime(2025, 5, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 8, 31.8f },
                    { 76, null, null, "Post-emergency follow-up, recovering well", 28, null, null, new DateTime(2025, 5, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 9, 31.5f },
                    { 77, null, null, "Turtle wellness check, shell in good condition", 29, null, null, new DateTime(2025, 3, 28, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 0.9f },
                    { 78, null, null, "Shell conditioning treatment", 29, null, null, new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 10, 1f },
                    { 79, null, 5, "Large breed wellness check", 30, 72, 38.3f, new DateTime(2025, 1, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 55f },
                    { 80, "Reluctant to climb stairs", null, "Joint stiffness, started glucosamine", 30, null, null, new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 54.5f },
                    { 81, null, null, "Joint supplements helping, more mobile", 30, null, null, new DateTime(2025, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 9, 54.8f },
                    { 82, null, null, "Annual vaccinations", 30, null, null, new DateTime(2025, 11, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), 3, 55.2f },
                    { 83, null, 5, "Routine checkup, playful temperament", 31, 120, 38.6f, new DateTime(2025, 2, 14, 9, 45, 0, 0, DateTimeKind.Unspecified), 1, 3.2f },
                    { 84, null, null, "Dental exam, teeth clean", 31, null, null, new DateTime(2025, 6, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, 3.4f },
                    { 85, null, null, "Booster vaccinations", 31, null, null, new DateTime(2025, 10, 20, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, 3.5f },
                    { 86, null, null, "Kitten vaccination series", 32, null, 38.9f, new DateTime(2025, 4, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 2.5f },
                    { 87, null, 5, "Annual checkup, thriving", 32, null, 38.7f, new DateTime(2025, 10, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 4.8f },
                    { 88, null, 5, "Wellness check, slight dental tartar", 33, 115, 38.6f, new DateTime(2025, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 6f },
                    { 89, null, null, "Professional dental cleaning", 33, null, null, new DateTime(2025, 5, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), 6, 6.1f },
                    { 90, null, null, "Annual vaccinations", 33, null, null, new DateTime(2025, 11, 2, 15, 45, 0, 0, DateTimeKind.Unspecified), 3, 6.2f },
                    { 91, null, 5, "Annual checkup, heart murmur grade 2 noted", 34, 105, 38.5f, new DateTime(2025, 2, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 7.8f },
                    { 92, null, null, "Echocardiogram performed, monitoring recommended", 34, null, null, new DateTime(2025, 3, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 7.7f },
                    { 93, null, null, "Cardiac follow-up, stable", 34, 100, null, new DateTime(2025, 9, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 9, 7.9f },
                    { 94, null, 5, "Routine wellness exam", 35, null, 38.8f, new DateTime(2025, 4, 20, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 4.3f },
                    { 95, null, null, "Parasite prevention treatment", 35, null, null, new DateTime(2025, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 7, 4.5f },
                    { 96, null, null, "New patient exam, healthy young rabbit", 36, null, null, new DateTime(2025, 7, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 1.8f },
                    { 97, null, null, "Dental check, incisors normal", 36, null, null, new DateTime(2025, 12, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), 6, 2.2f },
                    { 98, null, 5, "Annual exam, compact and healthy", 37, 95, 38.5f, new DateTime(2025, 1, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 12.5f },
                    { 99, null, null, "Vaccination booster", 37, null, null, new DateTime(2025, 6, 28, 16, 15, 0, 0, DateTimeKind.Unspecified), 3, 12.8f },
                    { 100, null, null, "Flea and worm preventive", 37, null, null, new DateTime(2025, 11, 20, 8, 45, 0, 0, DateTimeKind.Unspecified), 7, 12.6f },
                    { 101, null, 5, "Annual wellness check, luxurious coat", 38, 148, 38.7f, new DateTime(2025, 2, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 5.5f },
                    { 102, "Occasional retching", null, "Hairball issues, prescribed laxative paste", 38, null, null, new DateTime(2025, 7, 22, 13, 45, 0, 0, DateTimeKind.Unspecified), 2, 5.6f },
                    { 103, null, null, "Vaccinations updated", 38, null, null, new DateTime(2025, 12, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 5.7f },
                    { 104, null, null, "Puppy vaccinations", 39, null, 38.7f, new DateTime(2025, 3, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, 5f },
                    { 105, null, 5, "Nine-month checkup, developing well", 39, null, 38.5f, new DateTime(2025, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.8f },
                    { 106, null, 5, "Annual checkup, healthy dachshund", 40, 105, 38.5f, new DateTime(2025, 1, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 9.5f },
                    { 107, "Reluctant to jump", null, "Back pain, anti-inflammatory prescribed", 40, null, null, new DateTime(2025, 5, 12, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, 9.7f },
                    { 108, null, null, "Back pain follow-up, much improved", 40, null, null, new DateTime(2025, 6, 2, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 9.6f },
                    { 109, null, 5, "Annual exam, large breed in great shape", 41, 75, 38.3f, new DateTime(2025, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 45f },
                    { 110, null, null, "Annual vaccinations", 41, null, null, new DateTime(2025, 4, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, 45.5f },
                    { 111, "Restless, distended abdomen", null, "Emergency: bloat symptoms, stomach torsion ruled out", 41, null, 39f, new DateTime(2025, 8, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 8, 44.8f },
                    { 112, null, null, "Post-emergency follow-up, eating normally", 41, null, null, new DateTime(2025, 8, 7, 9, 30, 0, 0, DateTimeKind.Unspecified), 9, 44.5f },
                    { 113, null, 5, "Routine checkup, friendly temperament", 42, null, 38.8f, new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 4.2f },
                    { 114, null, null, "Annual booster vaccinations", 42, null, null, new DateTime(2025, 11, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), 3, 4.4f },
                    { 115, null, null, "New patient exam, young hamster in good health", 43, null, null, new DateTime(2025, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.12f },
                    { 116, null, null, "Nail trim and general check", 43, null, null, new DateTime(2025, 12, 8, 13, 15, 0, 0, DateTimeKind.Unspecified), 10, 0.14f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
