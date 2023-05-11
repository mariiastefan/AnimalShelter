using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;

namespace DogShelter.Services
{
    public class DogService
    {
        private readonly UnitOfWork unitOfWork;
        public DogService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddDog(AddDogDto dog)
        {
            if (dog == null)
            {
                return;
            }

            var newDetails = new Details
            {
                Type = dog.Type,
                Photo = dog.Photo,
                Breed = dog.Breed,
                DateOfBirth = dog.DateOfBirth,
                Gender = dog.Gender,
                Weight = dog.Weight,
                Color = dog.Color,
                TypeOfFood = dog.TypeOfFood
            };

            unitOfWork.Details.Insert(newDetails);

            var newDog = new Dog
            {
                Name = dog.Name,
                AdoptionStatus = dog.AdoptionStatus,
                IdDetails = newDetails.Id,
                Details = newDetails
            };

            unitOfWork.Dogs.Insert(newDog);
            unitOfWork.SaveChanges();
        }

        public List<Dog> GetAll()
        {
            var results = unitOfWork.Dogs.GetAll();

            foreach (Dog dog in results)
            {
                var details = unitOfWork.Details.GetById(dog.IdDetails);

                dog.Details = details;
            }

            return results;
        }

        public Dog GetById(int dogId)
        {
            var dog = unitOfWork.Dogs.GetById(dogId);

            var details = unitOfWork.Details.GetById(dog.IdDetails);

            dog.Details = details;

            var result = dog;

            return result;
        }

        public bool DeleteDog(int dogId)
        {
            if (dogId == 0)
            {
                return false;
            }

            var result = unitOfWork.Dogs.GetById(dogId);
            if (result == null) return false;


            unitOfWork.Dogs.Remove(result);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
