using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Breed
{
    public class BreedDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SpeciesId { get; set; }

        public SpeciesIndexViewModel Species { get; set; } = null!;

    }
}
