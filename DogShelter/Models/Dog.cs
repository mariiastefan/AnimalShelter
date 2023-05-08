using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string AdoptionStatus { get; set; }

        [ForeignKey("Details")]
        public int IdDetails { get; set; }
        public Details Details { get; set; }
    }
}
