using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
