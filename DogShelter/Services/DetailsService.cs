using DogShelter.DTOs;
using DogShelter.Models;

namespace DogShelter.Services
{
    public class DetailsService
    {
        private readonly UnitOfWork unitOfWork;

        public DetailsService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Details AddDetails(AddDogDto dog)
        {
            var newDetails = new Details
            {
                Type = "dog",
                Photo = dog.Photo,
                Breed = dog.Breed,
                DateOfBirth = dog.DateOfBirth,
                Gender = dog.Gender,
                Weight = dog.Weight,
                Color = dog.Color,
                TypeOfFood = dog.TypeOfFood
            };

            unitOfWork.Details.Insert(newDetails);

            return newDetails;
        }

        public Details GetById(int detailsId)
        {
            var details = unitOfWork.Details.GetById(detailsId);

            var result = details;

            return result;
        }

        public bool DeleteDetails(int detailsId)
        {
            if (detailsId == 0) return false;

            var result = unitOfWork.Details.GetById(detailsId);
            if (result == null) return false;

            unitOfWork.Details.Remove(result);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
