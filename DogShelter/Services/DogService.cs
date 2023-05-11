using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;

namespace DogShelter.Services
{
    public class DogService
    {
        private DetailsService detailsService { get; set; }
        private readonly UnitOfWork unitOfWork;
        public DogService(UnitOfWork unitOfWork, DetailsService detailsService)
        {
            this.unitOfWork = unitOfWork;
            this.detailsService = detailsService;
        }

        public void AddDog(AddDogDto dog)
        {
            if (dog == null)
            {
                return;
            }

            var details = detailsService.AddDetails(dog);

            var newDog = new Dog
            {
                Name = dog.Name,
                AdoptionStatus = "pending",
                IdDetails = details.Id,
                Details = details
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

        public bool EditAdoptionStatus(UpdateAdoptionStatusDto payload)
        {
            if (payload == null || payload.AdoptionStatus == null)
            {
                return false;
            }

            var result = unitOfWork.Dogs.GetById(payload.IdDog);
            if (result == null) return false;

            result.AdoptionStatus = payload.AdoptionStatus;

            unitOfWork.Dogs.Update(result);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool EditDogDetails(DogDetailsUpdateDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var dog = unitOfWork.Dogs.GetById(payload.IdDog);
            if (dog == null) return false;

            var details = unitOfWork.Details.GetById(dog.IdDetails);
            dog.Details = details;

            if (payload.NewName != "string") dog.Name = payload.NewName;
            if (payload.NewType != "string") details.Type = payload.NewType;
            if (payload.NewPhoto != "string") details.Photo = payload.NewPhoto;
            if (payload.NewBreed != "string") details.Breed = payload.NewBreed;
            if (payload.NewDateOfBirth.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy")) details.DateOfBirth = payload.NewDateOfBirth;
            if (payload.NewGender != "string")details.Gender = payload.NewGender;
            if (payload.NewWeight != 0) details.Weight = payload.NewWeight;
            if (payload.NewColor != "string") details.Color = payload.NewColor;
            if (payload.NewTypeOfFood != "string") details.TypeOfFood = payload.NewTypeOfFood;

            unitOfWork.Dogs.Update(dog);
            unitOfWork.Details.Update(details);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteDog(int dogId)
        {
            if (dogId == 0) return false;

            var result = unitOfWork.Dogs.GetById(dogId);
            if (result == null) return false;

            var detailsResult = detailsService.DeleteDetails(result.IdDetails);
            if (detailsResult == false) return false;

            unitOfWork.Dogs.Remove(result);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
