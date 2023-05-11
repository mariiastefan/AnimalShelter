namespace DogShelter.DTOs
{
    public class DogDetailsUpdateDto
    {
        public int IdDog { get; set; }

        public string NewName { get; set; }

        public string NewType { get; set; }

        public string NewPhoto { get; set; }

        public string NewBreed { get; set; }

        public DateTime NewDateOfBirth { get; set; }

        public string NewGender { get; set; }

        public float NewWeight { get; set; }

        public string NewColor { get; set; }

        public string NewTypeOfFood { get; set; }
    }
}
