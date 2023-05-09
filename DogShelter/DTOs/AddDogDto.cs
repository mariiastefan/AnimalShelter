using DogShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogShelter.DTOs
{
    public class AddDogDto
    {
        public string Name { get; set; }

        public string AdoptionStatus { get; set; }

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
