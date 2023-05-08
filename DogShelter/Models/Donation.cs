using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class Donation : BaseEntity
    {
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }

        public DateTime DonationDate { get; set; }
    }
}
