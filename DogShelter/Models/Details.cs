namespace DogShelter.Models
{
    public class Details: BaseEntity
    {
        public string Type { get; set; }

        public string Photo { get; set; }

        public string Breed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public float Weight { get; set; }

        public string Color { get; set; }

        public string TypeOfFood { get; set; }
    }
}
