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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the dog details: " + ex.Message);
                throw new Exception("An error occurred while adding the dog details.", ex);
            }
        }

        public Details GetById(int detailsId)
        {
            try
            {
                var details = unitOfWork.Details.GetById(detailsId);
                var result = details;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the details: " + ex.Message);
                throw new Exception("An error occurred while retrieving the details.", ex);
            }
        }

        public bool DeleteDetails(int detailsId)
        {
            try
            {
                if (detailsId == 0)
                {
                    return false;
                }

                var result = unitOfWork.Details.GetById(detailsId);
                if (result == null)
                {
                    return false;
                }

                unitOfWork.Details.Remove(result);
                unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the details: " + ex.Message);
                throw new Exception("An error occurred while deleting the details.", ex);
            }
        }
    }
}
