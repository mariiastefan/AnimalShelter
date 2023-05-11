using DogShelter.Models;

namespace DogShelter.DTOs
{
    public class DonationDto
    {
        public int IdUser { get; set; }

        public int Amount { get; set; }

        public DateTime DonationDate { get; set; }
    }
}
