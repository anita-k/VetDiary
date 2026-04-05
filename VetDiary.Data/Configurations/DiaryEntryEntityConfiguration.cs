using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetDiary.Data.Models;

namespace VetDiary.Data.Configurations
{
    public class DiaryEntryEntityConfiguration : IEntityTypeConfiguration<DiaryEntry>
    {
        public ICollection<DiaryEntry> DiaryEntries { get; private set; } = new List<DiaryEntry>
        {
            // Pet 1 (Buddy) - 3 entries
            new DiaryEntry { Id = 1, PetId = 1, VisitDate = new DateTime(2025, 1, 15, 9, 0, 0), VisitReasonId = 1, Description = "Annual checkup, all vitals normal", Weight = 28.5f, Temperature = 38.5f, Pulse = 90, BodyConditionScore = 5 },
            new DiaryEntry { Id = 2, PetId = 1, VisitDate = new DateTime(2025, 4, 10, 14, 30, 0), VisitReasonId = 3, Description = "Rabies vaccination booster", Weight = 29.0f, Temperature = 38.6f },
            new DiaryEntry { Id = 3, PetId = 1, VisitDate = new DateTime(2025, 9, 20, 11, 15, 0), VisitReasonId = 7, Description = "Flea and tick preventive treatment", Weight = 28.8f },

            // Pet 2 (Whiskers) - 2 entries
            new DiaryEntry { Id = 4, PetId = 2, VisitDate = new DateTime(2025, 2, 5, 10, 0, 0), VisitReasonId = 1, Description = "Routine exam, healthy coat", Weight = 4.2f, Temperature = 38.8f, Pulse = 160, BodyConditionScore = 5 },
            new DiaryEntry { Id = 5, PetId = 2, VisitDate = new DateTime(2025, 8, 12, 15, 45, 0), VisitReasonId = 6, Description = "Dental cleaning, minor tartar removed", Weight = 4.3f },

            // Pet 3 (Max) - 4 entries
            new DiaryEntry { Id = 6, PetId = 3, VisitDate = new DateTime(2025, 1, 8, 8, 30, 0), VisitReasonId = 1, Description = "Annual wellness check", Weight = 34.0f, Temperature = 38.4f, Pulse = 85, BodyConditionScore = 6 },
            new DiaryEntry { Id = 7, PetId = 3, VisitDate = new DateTime(2025, 3, 22, 13, 0, 0), VisitReasonId = 2, Description = "Mild ear infection, prescribed antibiotics", Weight = 33.8f, Temperature = 39.1f, Behaviour = "Scratching ears frequently" },
            new DiaryEntry { Id = 8, PetId = 3, VisitDate = new DateTime(2025, 4, 5, 10, 30, 0), VisitReasonId = 9, Description = "Follow-up on ear infection, resolved", Weight = 34.1f, Temperature = 38.5f },
            new DiaryEntry { Id = 9, PetId = 3, VisitDate = new DateTime(2025, 10, 15, 16, 0, 0), VisitReasonId = 3, Description = "Annual vaccinations updated", Weight = 34.5f },

            // Pet 4 (Luna) - 3 entries
            new DiaryEntry { Id = 10, PetId = 4, VisitDate = new DateTime(2025, 2, 18, 11, 0, 0), VisitReasonId = 3, Description = "Core vaccinations", Weight = 3.8f, Temperature = 38.7f },
            new DiaryEntry { Id = 11, PetId = 4, VisitDate = new DateTime(2025, 6, 30, 9, 30, 0), VisitReasonId = 1, Description = "Six-month checkup, gaining weight well", Weight = 4.1f, Temperature = 38.9f, BodyConditionScore = 5 },
            new DiaryEntry { Id = 12, PetId = 4, VisitDate = new DateTime(2025, 11, 5, 14, 0, 0), VisitReasonId = 7, Description = "Deworming treatment", Weight = 4.4f },

            // Pet 5 (Charlie) - 2 entries
            new DiaryEntry { Id = 13, PetId = 5, VisitDate = new DateTime(2025, 3, 12, 15, 0, 0), VisitReasonId = 1, Description = "General health check, excellent condition", Weight = 30.2f, Temperature = 38.5f, Pulse = 88, BodyConditionScore = 5 },
            new DiaryEntry { Id = 14, PetId = 5, VisitDate = new DateTime(2025, 9, 8, 10, 45, 0), VisitReasonId = 3, Description = "Booster vaccinations", Weight = 31.0f },

            // Pet 6 (Daisy) - 3 entries
            new DiaryEntry { Id = 15, PetId = 6, VisitDate = new DateTime(2025, 1, 22, 12, 0, 0), VisitReasonId = 2, Description = "Skin allergy, prescribed antihistamines", Weight = 11.5f, Temperature = 38.6f, Behaviour = "Excessive licking of paws" },
            new DiaryEntry { Id = 16, PetId = 6, VisitDate = new DateTime(2025, 2, 19, 9, 15, 0), VisitReasonId = 9, Description = "Allergy follow-up, symptoms improving", Weight = 11.6f },
            new DiaryEntry { Id = 17, PetId = 6, VisitDate = new DateTime(2025, 7, 14, 16, 30, 0), VisitReasonId = 1, Description = "Routine checkup, allergy managed", Weight = 11.8f, Temperature = 38.5f, BodyConditionScore = 5 },

            // Pet 7 (Coco) - 2 entries
            new DiaryEntry { Id = 18, PetId = 7, VisitDate = new DateTime(2025, 4, 3, 8, 0, 0), VisitReasonId = 3, Description = "First vaccination series", Weight = 3.0f, Temperature = 38.8f },
            new DiaryEntry { Id = 19, PetId = 7, VisitDate = new DateTime(2025, 5, 1, 11, 30, 0), VisitReasonId = 3, Description = "Second vaccination dose", Weight = 3.3f, Temperature = 38.7f },

            // Pet 8 (Rocky) - 4 entries
            new DiaryEntry { Id = 20, PetId = 8, VisitDate = new DateTime(2025, 1, 5, 9, 0, 0), VisitReasonId = 1, Description = "Senior wellness exam", Weight = 42.0f, Temperature = 38.3f, Pulse = 80, BodyConditionScore = 6 },
            new DiaryEntry { Id = 21, PetId = 8, VisitDate = new DateTime(2025, 3, 18, 13, 30, 0), VisitReasonId = 5, Description = "Minor limp on front right leg, X-ray clear", Weight = 41.8f, Behaviour = "Slight limping" },
            new DiaryEntry { Id = 22, PetId = 8, VisitDate = new DateTime(2025, 6, 25, 10, 0, 0), VisitReasonId = 6, Description = "Dental extraction of cracked molar", Weight = 41.5f, Temperature = 38.4f },
            new DiaryEntry { Id = 23, PetId = 8, VisitDate = new DateTime(2025, 12, 2, 15, 0, 0), VisitReasonId = 1, Description = "End-of-year checkup, good for his age", Weight = 41.0f, Temperature = 38.4f, BodyConditionScore = 5 },

            // Pet 9 (Bella) - 3 entries
            new DiaryEntry { Id = 24, PetId = 9, VisitDate = new DateTime(2025, 2, 28, 8, 30, 0), VisitReasonId = 4, Description = "Spay surgery, uneventful recovery", Weight = 8.5f, Temperature = 38.6f },
            new DiaryEntry { Id = 25, PetId = 9, VisitDate = new DateTime(2025, 3, 14, 14, 0, 0), VisitReasonId = 9, Description = "Post-surgery checkup, sutures healing well", Weight = 8.3f },
            new DiaryEntry { Id = 26, PetId = 9, VisitDate = new DateTime(2025, 8, 20, 11, 0, 0), VisitReasonId = 1, Description = "Routine exam, fully recovered", Weight = 8.8f, Temperature = 38.5f, BodyConditionScore = 5 },

            // Pet 10 (Milo) - 2 entries
            new DiaryEntry { Id = 27, PetId = 10, VisitDate = new DateTime(2025, 5, 10, 9, 45, 0), VisitReasonId = 3, Description = "Kitten vaccinations", Weight = 2.8f, Temperature = 38.9f },
            new DiaryEntry { Id = 28, PetId = 10, VisitDate = new DateTime(2025, 11, 18, 16, 15, 0), VisitReasonId = 1, Description = "Annual checkup, active and healthy", Weight = 4.5f, Temperature = 38.7f, BodyConditionScore = 5 },

            // Pet 11 (Rosie) - 3 entries
            new DiaryEntry { Id = 29, PetId = 11, VisitDate = new DateTime(2025, 1, 30, 10, 30, 0), VisitReasonId = 1, Description = "Routine checkup, coat in good condition", Weight = 3.9f, Temperature = 38.8f, Pulse = 155, BodyConditionScore = 5 },
            new DiaryEntry { Id = 30, PetId = 11, VisitDate = new DateTime(2025, 5, 22, 14, 15, 0), VisitReasonId = 2, Description = "Vomiting episodes, dietary adjustment recommended", Weight = 3.7f, Temperature = 39.0f, Behaviour = "Lethargy, reduced appetite" },
            new DiaryEntry { Id = 31, PetId = 11, VisitDate = new DateTime(2025, 6, 5, 9, 0, 0), VisitReasonId = 9, Description = "Follow-up, eating normally again", Weight = 3.8f },

            // Pet 12 (Oscar) - 3 entries
            new DiaryEntry { Id = 32, PetId = 12, VisitDate = new DateTime(2025, 2, 10, 11, 30, 0), VisitReasonId = 1, Description = "Annual exam, slight weight gain noted", Weight = 14.0f, Temperature = 38.5f, Pulse = 100, BodyConditionScore = 7 },
            new DiaryEntry { Id = 33, PetId = 12, VisitDate = new DateTime(2025, 6, 15, 15, 30, 0), VisitReasonId = 7, Description = "Heartworm preventive treatment", Weight = 13.5f },
            new DiaryEntry { Id = 34, PetId = 12, VisitDate = new DateTime(2025, 10, 28, 8, 45, 0), VisitReasonId = 3, Description = "Vaccination booster", Weight = 13.2f, Temperature = 38.5f, BodyConditionScore = 6 },

            // Pet 13 (Nala) - 2 entries
            new DiaryEntry { Id = 35, PetId = 13, VisitDate = new DateTime(2025, 3, 5, 9, 0, 0), VisitReasonId = 4, Description = "Spay surgery, smooth procedure", Weight = 3.6f, Temperature = 38.7f },
            new DiaryEntry { Id = 36, PetId = 13, VisitDate = new DateTime(2025, 3, 19, 10, 0, 0), VisitReasonId = 9, Description = "Post-op check, healing perfectly", Weight = 3.5f },

            // Pet 14 (Thumper) - 2 entries
            new DiaryEntry { Id = 37, PetId = 14, VisitDate = new DateTime(2025, 2, 15, 13, 0, 0), VisitReasonId = 1, Description = "New patient exam, healthy rabbit", Weight = 2.1f, Temperature = 39.2f },
            new DiaryEntry { Id = 38, PetId = 14, VisitDate = new DateTime(2025, 8, 8, 17, 0, 0), VisitReasonId = 6, Description = "Dental check, teeth wearing evenly", Weight = 2.4f },

            // Pet 15 (Duke) - 5 entries
            new DiaryEntry { Id = 39, PetId = 15, VisitDate = new DateTime(2025, 1, 10, 8, 0, 0), VisitReasonId = 1, Description = "Senior exam, mild arthritis noted", Weight = 27.0f, Temperature = 38.3f, Pulse = 78, BodyConditionScore = 5, Behaviour = "Stiffness after rest" },
            new DiaryEntry { Id = 40, PetId = 15, VisitDate = new DateTime(2025, 3, 25, 12, 30, 0), VisitReasonId = 2, Description = "Joint pain management, started on supplements", Weight = 26.8f },
            new DiaryEntry { Id = 41, PetId = 15, VisitDate = new DateTime(2025, 5, 30, 10, 15, 0), VisitReasonId = 9, Description = "Arthritis follow-up, mobility improved", Weight = 26.5f },
            new DiaryEntry { Id = 42, PetId = 15, VisitDate = new DateTime(2025, 8, 15, 14, 45, 0), VisitReasonId = 3, Description = "Annual vaccinations", Weight = 26.7f, Temperature = 38.4f },
            new DiaryEntry { Id = 43, PetId = 15, VisitDate = new DateTime(2025, 12, 10, 9, 30, 0), VisitReasonId = 1, Description = "Year-end wellness check, stable condition", Weight = 26.3f, Temperature = 38.3f, BodyConditionScore = 5 },

            // Pet 16 (Poppy) - 3 entries
            new DiaryEntry { Id = 44, PetId = 16, VisitDate = new DateTime(2025, 2, 22, 11, 0, 0), VisitReasonId = 1, Description = "Routine checkup, good health", Weight = 4.0f, Temperature = 38.8f, BodyConditionScore = 5 },
            new DiaryEntry { Id = 45, PetId = 16, VisitDate = new DateTime(2025, 7, 8, 16, 0, 0), VisitReasonId = 7, Description = "Flea treatment applied", Weight = 4.1f },
            new DiaryEntry { Id = 46, PetId = 16, VisitDate = new DateTime(2025, 11, 30, 13, 30, 0), VisitReasonId = 3, Description = "Booster vaccinations", Weight = 4.2f },

            // Pet 17 (Rex) - 2 entries
            new DiaryEntry { Id = 47, PetId = 17, VisitDate = new DateTime(2025, 4, 14, 9, 0, 0), VisitReasonId = 1, Description = "First annual checkup", Weight = 35.0f, Temperature = 38.5f, Pulse = 82, BodyConditionScore = 5 },
            new DiaryEntry { Id = 48, PetId = 17, VisitDate = new DateTime(2025, 10, 3, 15, 15, 0), VisitReasonId = 5, Description = "Minor cut on paw, cleaned and bandaged", Weight = 36.2f, Behaviour = "Limping slightly" },

            // Pet 18 (Ziggy) - 2 entries
            new DiaryEntry { Id = 49, PetId = 18, VisitDate = new DateTime(2025, 5, 20, 10, 30, 0), VisitReasonId = 1, Description = "Wellness exam, feathers in good condition", Weight = 0.35f },
            new DiaryEntry { Id = 50, PetId = 18, VisitDate = new DateTime(2025, 11, 12, 14, 0, 0), VisitReasonId = 10, Description = "Wing clipping", Weight = 0.36f },

            // Pet 19 (Cleo) - 2 entries
            new DiaryEntry { Id = 51, PetId = 19, VisitDate = new DateTime(2025, 6, 8, 8, 15, 0), VisitReasonId = 3, Description = "Kitten vaccination series", Weight = 1.8f, Temperature = 38.9f },
            new DiaryEntry { Id = 52, PetId = 19, VisitDate = new DateTime(2025, 7, 6, 11, 45, 0), VisitReasonId = 3, Description = "Second dose vaccinations", Weight = 2.2f, Temperature = 38.8f },

            // Pet 20 (Cooper) - 3 entries
            new DiaryEntry { Id = 53, PetId = 20, VisitDate = new DateTime(2025, 1, 25, 14, 30, 0), VisitReasonId = 1, Description = "Annual wellness check", Weight = 22.0f, Temperature = 38.5f, Pulse = 92, BodyConditionScore = 5 },
            new DiaryEntry { Id = 54, PetId = 20, VisitDate = new DateTime(2025, 5, 15, 9, 0, 0), VisitReasonId = 3, Description = "Vaccination booster", Weight = 22.3f },
            new DiaryEntry { Id = 55, PetId = 20, VisitDate = new DateTime(2025, 9, 30, 16, 45, 0), VisitReasonId = 2, Description = "Mild stomach upset, prescribed probiotics", Weight = 22.1f, Temperature = 38.8f, Behaviour = "Reduced appetite" },

            // Pet 21 (Sadie) - 3 entries
            new DiaryEntry { Id = 56, PetId = 21, VisitDate = new DateTime(2025, 2, 3, 10, 0, 0), VisitReasonId = 1, Description = "Routine checkup, active and fit", Weight = 20.5f, Temperature = 38.4f, Pulse = 88, BodyConditionScore = 5 },
            new DiaryEntry { Id = 57, PetId = 21, VisitDate = new DateTime(2025, 6, 20, 13, 15, 0), VisitReasonId = 7, Description = "Tick prevention treatment", Weight = 20.8f },
            new DiaryEntry { Id = 58, PetId = 21, VisitDate = new DateTime(2025, 11, 8, 8, 30, 0), VisitReasonId = 3, Description = "Annual vaccinations", Weight = 21.0f },

            // Pet 22 (Simba) - 2 entries
            new DiaryEntry { Id = 59, PetId = 22, VisitDate = new DateTime(2025, 3, 15, 9, 0, 0), VisitReasonId = 4, Description = "Neuter surgery, routine", Weight = 4.5f, Temperature = 38.7f },
            new DiaryEntry { Id = 60, PetId = 22, VisitDate = new DateTime(2025, 3, 29, 11, 0, 0), VisitReasonId = 9, Description = "Post-neuter check, all good", Weight = 4.4f },

            // Pet 23 (Peanut) - 2 entries
            new DiaryEntry { Id = 61, PetId = 23, VisitDate = new DateTime(2025, 5, 5, 15, 30, 0), VisitReasonId = 1, Description = "Initial health assessment, healthy hamster", Weight = 0.14f },
            new DiaryEntry { Id = 62, PetId = 23, VisitDate = new DateTime(2025, 10, 22, 10, 45, 0), VisitReasonId = 2, Description = "Runny nose, prescribed medication", Weight = 0.15f, Behaviour = "Sneezing" },

            // Pet 24 (Tucker) - 3 entries
            new DiaryEntry { Id = 63, PetId = 24, VisitDate = new DateTime(2025, 1, 18, 12, 0, 0), VisitReasonId = 1, Description = "Annual exam, energetic and healthy", Weight = 7.5f, Temperature = 38.6f, Pulse = 110, BodyConditionScore = 5 },
            new DiaryEntry { Id = 64, PetId = 24, VisitDate = new DateTime(2025, 4, 25, 17, 30, 0), VisitReasonId = 5, Description = "Torn nail, treated and bandaged", Weight = 7.6f },
            new DiaryEntry { Id = 65, PetId = 24, VisitDate = new DateTime(2025, 9, 12, 9, 15, 0), VisitReasonId = 3, Description = "Vaccinations updated", Weight = 7.8f },

            // Pet 25 (Molly) - 2 entries
            new DiaryEntry { Id = 66, PetId = 25, VisitDate = new DateTime(2025, 3, 8, 14, 0, 0), VisitReasonId = 3, Description = "Puppy vaccinations", Weight = 10.2f, Temperature = 38.6f },
            new DiaryEntry { Id = 67, PetId = 25, VisitDate = new DateTime(2025, 8, 28, 10, 30, 0), VisitReasonId = 1, Description = "Six-month checkup, growing well", Weight = 12.5f, Temperature = 38.5f, BodyConditionScore = 5 },

            // Pet 26 (Shadow) - 4 entries
            new DiaryEntry { Id = 68, PetId = 26, VisitDate = new DateTime(2025, 1, 12, 9, 30, 0), VisitReasonId = 1, Description = "Senior cat exam, slight weight loss", Weight = 5.2f, Temperature = 38.7f, Pulse = 150, BodyConditionScore = 4 },
            new DiaryEntry { Id = 69, PetId = 26, VisitDate = new DateTime(2025, 2, 20, 11, 0, 0), VisitReasonId = 2, Description = "Blood work ordered, thyroid levels checked", Weight = 5.0f },
            new DiaryEntry { Id = 70, PetId = 26, VisitDate = new DateTime(2025, 3, 10, 15, 0, 0), VisitReasonId = 9, Description = "Results normal, dietary change recommended", Weight = 5.1f },
            new DiaryEntry { Id = 71, PetId = 26, VisitDate = new DateTime(2025, 9, 5, 13, 45, 0), VisitReasonId = 1, Description = "Follow-up, weight stabilized", Weight = 5.3f, Temperature = 38.6f, BodyConditionScore = 5 },

            // Pet 27 (Ginger) - 2 entries
            new DiaryEntry { Id = 72, PetId = 27, VisitDate = new DateTime(2025, 4, 18, 8, 0, 0), VisitReasonId = 1, Description = "Routine wellness check", Weight = 4.8f, Temperature = 38.8f, BodyConditionScore = 5 },
            new DiaryEntry { Id = 73, PetId = 27, VisitDate = new DateTime(2025, 10, 10, 16, 30, 0), VisitReasonId = 7, Description = "Flea treatment", Weight = 4.9f },

            // Pet 28 (Bruno) - 3 entries
            new DiaryEntry { Id = 74, PetId = 28, VisitDate = new DateTime(2025, 2, 8, 10, 15, 0), VisitReasonId = 1, Description = "Annual checkup, muscular build", Weight = 32.0f, Temperature = 38.4f, Pulse = 85, BodyConditionScore = 6 },
            new DiaryEntry { Id = 75, PetId = 28, VisitDate = new DateTime(2025, 5, 25, 12, 0, 0), VisitReasonId = 8, Description = "Emergency: ingested foreign object, induced vomiting", Weight = 31.8f, Temperature = 39.2f, Behaviour = "Restless, drooling" },
            new DiaryEntry { Id = 76, PetId = 28, VisitDate = new DateTime(2025, 5, 27, 9, 0, 0), VisitReasonId = 9, Description = "Post-emergency follow-up, recovering well", Weight = 31.5f },

            // Pet 29 (Shelly) - 2 entries
            new DiaryEntry { Id = 77, PetId = 29, VisitDate = new DateTime(2025, 3, 28, 14, 30, 0), VisitReasonId = 1, Description = "Turtle wellness check, shell in good condition", Weight = 0.9f },
            new DiaryEntry { Id = 78, PetId = 29, VisitDate = new DateTime(2025, 9, 15, 11, 0, 0), VisitReasonId = 10, Description = "Shell conditioning treatment", Weight = 1.0f },

            // Pet 30 (Zeus) - 4 entries
            new DiaryEntry { Id = 79, PetId = 30, VisitDate = new DateTime(2025, 1, 20, 8, 30, 0), VisitReasonId = 1, Description = "Large breed wellness check", Weight = 55.0f, Temperature = 38.3f, Pulse = 72, BodyConditionScore = 5 },
            new DiaryEntry { Id = 80, PetId = 30, VisitDate = new DateTime(2025, 4, 8, 15, 0, 0), VisitReasonId = 2, Description = "Joint stiffness, started glucosamine", Weight = 54.5f, Behaviour = "Reluctant to climb stairs" },
            new DiaryEntry { Id = 81, PetId = 30, VisitDate = new DateTime(2025, 7, 20, 10, 0, 0), VisitReasonId = 9, Description = "Joint supplements helping, more mobile", Weight = 54.8f },
            new DiaryEntry { Id = 82, PetId = 30, VisitDate = new DateTime(2025, 11, 25, 13, 30, 0), VisitReasonId = 3, Description = "Annual vaccinations", Weight = 55.2f },

            // Pet 31 (Lola) - 3 entries
            new DiaryEntry { Id = 83, PetId = 31, VisitDate = new DateTime(2025, 2, 14, 9, 45, 0), VisitReasonId = 1, Description = "Routine checkup, playful temperament", Weight = 3.2f, Temperature = 38.6f, Pulse = 120, BodyConditionScore = 5 },
            new DiaryEntry { Id = 84, PetId = 31, VisitDate = new DateTime(2025, 6, 10, 14, 0, 0), VisitReasonId = 6, Description = "Dental exam, teeth clean", Weight = 3.4f },
            new DiaryEntry { Id = 85, PetId = 31, VisitDate = new DateTime(2025, 10, 20, 11, 30, 0), VisitReasonId = 3, Description = "Booster vaccinations", Weight = 3.5f },

            // Pet 32 (Oliver) - 2 entries
            new DiaryEntry { Id = 86, PetId = 32, VisitDate = new DateTime(2025, 4, 2, 10, 0, 0), VisitReasonId = 3, Description = "Kitten vaccination series", Weight = 2.5f, Temperature = 38.9f },
            new DiaryEntry { Id = 87, PetId = 32, VisitDate = new DateTime(2025, 10, 5, 16, 0, 0), VisitReasonId = 1, Description = "Annual checkup, thriving", Weight = 4.8f, Temperature = 38.7f, BodyConditionScore = 5 },

            // Pet 33 (Teddy) - 3 entries
            new DiaryEntry { Id = 88, PetId = 33, VisitDate = new DateTime(2025, 1, 28, 8, 0, 0), VisitReasonId = 1, Description = "Wellness check, slight dental tartar", Weight = 6.0f, Temperature = 38.6f, Pulse = 115, BodyConditionScore = 5 },
            new DiaryEntry { Id = 89, PetId = 33, VisitDate = new DateTime(2025, 5, 18, 9, 30, 0), VisitReasonId = 6, Description = "Professional dental cleaning", Weight = 6.1f },
            new DiaryEntry { Id = 90, PetId = 33, VisitDate = new DateTime(2025, 11, 2, 15, 45, 0), VisitReasonId = 3, Description = "Annual vaccinations", Weight = 6.2f },

            // Pet 34 (Ruby) - 3 entries
            new DiaryEntry { Id = 91, PetId = 34, VisitDate = new DateTime(2025, 2, 25, 10, 30, 0), VisitReasonId = 1, Description = "Annual checkup, heart murmur grade 2 noted", Weight = 7.8f, Temperature = 38.5f, Pulse = 105, BodyConditionScore = 5 },
            new DiaryEntry { Id = 92, PetId = 34, VisitDate = new DateTime(2025, 3, 15, 13, 0, 0), VisitReasonId = 2, Description = "Echocardiogram performed, monitoring recommended", Weight = 7.7f },
            new DiaryEntry { Id = 93, PetId = 34, VisitDate = new DateTime(2025, 9, 10, 14, 30, 0), VisitReasonId = 9, Description = "Cardiac follow-up, stable", Weight = 7.9f, Pulse = 100 },

            // Pet 35 (Leo) - 2 entries
            new DiaryEntry { Id = 94, PetId = 35, VisitDate = new DateTime(2025, 4, 20, 11, 15, 0), VisitReasonId = 1, Description = "Routine wellness exam", Weight = 4.3f, Temperature = 38.8f, BodyConditionScore = 5 },
            new DiaryEntry { Id = 95, PetId = 35, VisitDate = new DateTime(2025, 10, 30, 9, 0, 0), VisitReasonId = 7, Description = "Parasite prevention treatment", Weight = 4.5f },

            // Pet 36 (Biscuit) - 2 entries
            new DiaryEntry { Id = 96, PetId = 36, VisitDate = new DateTime(2025, 7, 10, 15, 0, 0), VisitReasonId = 1, Description = "New patient exam, healthy young rabbit", Weight = 1.8f },
            new DiaryEntry { Id = 97, PetId = 36, VisitDate = new DateTime(2025, 12, 5, 12, 30, 0), VisitReasonId = 6, Description = "Dental check, incisors normal", Weight = 2.2f },

            // Pet 37 (Finn) - 3 entries
            new DiaryEntry { Id = 98, PetId = 37, VisitDate = new DateTime(2025, 1, 14, 10, 0, 0), VisitReasonId = 1, Description = "Annual exam, compact and healthy", Weight = 12.5f, Temperature = 38.5f, Pulse = 95, BodyConditionScore = 5 },
            new DiaryEntry { Id = 99, PetId = 37, VisitDate = new DateTime(2025, 6, 28, 16, 15, 0), VisitReasonId = 3, Description = "Vaccination booster", Weight = 12.8f },
            new DiaryEntry { Id = 100, PetId = 37, VisitDate = new DateTime(2025, 11, 20, 8, 45, 0), VisitReasonId = 7, Description = "Flea and worm preventive", Weight = 12.6f },

            // Pet 38 (Willow) - 3 entries
            new DiaryEntry { Id = 101, PetId = 38, VisitDate = new DateTime(2025, 2, 12, 9, 0, 0), VisitReasonId = 1, Description = "Annual wellness check, luxurious coat", Weight = 5.5f, Temperature = 38.7f, Pulse = 148, BodyConditionScore = 5 },
            new DiaryEntry { Id = 102, PetId = 38, VisitDate = new DateTime(2025, 7, 22, 13, 45, 0), VisitReasonId = 2, Description = "Hairball issues, prescribed laxative paste", Weight = 5.6f, Behaviour = "Occasional retching" },
            new DiaryEntry { Id = 103, PetId = 38, VisitDate = new DateTime(2025, 12, 1, 11, 0, 0), VisitReasonId = 3, Description = "Vaccinations updated", Weight = 5.7f },

            // Pet 39 (Archie) - 2 entries
            new DiaryEntry { Id = 104, PetId = 39, VisitDate = new DateTime(2025, 3, 20, 14, 30, 0), VisitReasonId = 3, Description = "Puppy vaccinations", Weight = 5.0f, Temperature = 38.7f },
            new DiaryEntry { Id = 105, PetId = 39, VisitDate = new DateTime(2025, 9, 25, 10, 0, 0), VisitReasonId = 1, Description = "Nine-month checkup, developing well", Weight = 8.8f, Temperature = 38.5f, BodyConditionScore = 5 },

            // Pet 40 (Pepper) - 3 entries
            new DiaryEntry { Id = 106, PetId = 40, VisitDate = new DateTime(2025, 1, 7, 8, 30, 0), VisitReasonId = 1, Description = "Annual checkup, healthy dachshund", Weight = 9.5f, Temperature = 38.5f, Pulse = 105, BodyConditionScore = 5 },
            new DiaryEntry { Id = 107, PetId = 40, VisitDate = new DateTime(2025, 5, 12, 15, 30, 0), VisitReasonId = 2, Description = "Back pain, anti-inflammatory prescribed", Weight = 9.7f, Behaviour = "Reluctant to jump" },
            new DiaryEntry { Id = 108, PetId = 40, VisitDate = new DateTime(2025, 6, 2, 10, 15, 0), VisitReasonId = 9, Description = "Back pain follow-up, much improved", Weight = 9.6f },

            // Pet 41 (Bear) - 4 entries
            new DiaryEntry { Id = 109, PetId = 41, VisitDate = new DateTime(2025, 1, 3, 9, 0, 0), VisitReasonId = 1, Description = "Annual exam, large breed in great shape", Weight = 45.0f, Temperature = 38.3f, Pulse = 75, BodyConditionScore = 5 },
            new DiaryEntry { Id = 110, PetId = 41, VisitDate = new DateTime(2025, 4, 15, 11, 30, 0), VisitReasonId = 3, Description = "Annual vaccinations", Weight = 45.5f },
            new DiaryEntry { Id = 111, PetId = 41, VisitDate = new DateTime(2025, 8, 5, 12, 0, 0), VisitReasonId = 8, Description = "Emergency: bloat symptoms, stomach torsion ruled out", Weight = 44.8f, Temperature = 39.0f, Behaviour = "Restless, distended abdomen" },
            new DiaryEntry { Id = 112, PetId = 41, VisitDate = new DateTime(2025, 8, 7, 9, 30, 0), VisitReasonId = 9, Description = "Post-emergency follow-up, eating normally", Weight = 44.5f },

            // Pet 42 (Mittens) - 2 entries
            new DiaryEntry { Id = 113, PetId = 42, VisitDate = new DateTime(2025, 5, 2, 14, 0, 0), VisitReasonId = 1, Description = "Routine checkup, friendly temperament", Weight = 4.2f, Temperature = 38.8f, BodyConditionScore = 5 },
            new DiaryEntry { Id = 114, PetId = 42, VisitDate = new DateTime(2025, 11, 15, 10, 45, 0), VisitReasonId = 3, Description = "Annual booster vaccinations", Weight = 4.4f },

            // Pet 43 (Hazel) - 2 entries
            new DiaryEntry { Id = 115, PetId = 43, VisitDate = new DateTime(2025, 7, 1, 16, 0, 0), VisitReasonId = 1, Description = "New patient exam, young hamster in good health", Weight = 0.12f },
            new DiaryEntry { Id = 116, PetId = 43, VisitDate = new DateTime(2025, 12, 8, 13, 15, 0), VisitReasonId = 10, Description = "Nail trim and general check", Weight = 0.14f },
        };

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

            builder.HasData(DiaryEntries);
        }
    }
}
