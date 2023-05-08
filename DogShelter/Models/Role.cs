using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class Role : BaseEntity
    {
        public string Type { get; set; }
    }
}
