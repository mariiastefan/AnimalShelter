using System.ComponentModel.DataAnnotations.Schema;

namespace DogShelter.Models
{
    public class Adoption : BaseEntity
    {
        [ForeignKey("Dog")]
        public int IdDog { get; set; }
        public Dog Dog { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        public DateTime AdoptionDate { get; set; }
    }
}
