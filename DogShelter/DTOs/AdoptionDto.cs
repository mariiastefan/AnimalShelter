using DogShelter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogShelter.DTOs
{
    public class AdoptionDto
    {
        public int IdDog { get; set; }
        public int IdUser { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}
