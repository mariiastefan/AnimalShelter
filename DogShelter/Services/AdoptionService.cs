using DogShelter.DTOs;
using DogShelter.Models;

namespace DogShelter.Services
{
    public class AdoptionService
    {
        private readonly UnitOfWork unitOfWork;

        public AdoptionService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddAdoption(AdoptionDto adoptionDto)
        {
            try
            {
                if (adoptionDto == null)
                {
                    return;
                }
                var adoption = new Adoption
                {
                    IdDog = adoptionDto.IdDog,
                    IdUser = adoptionDto.IdUser,
                    AdoptionDate = adoptionDto.AdoptionDate

                };

                var result = unitOfWork.Dogs.GetById(adoptionDto.IdDog);

                if (result == null)
                {
                    throw new Exception("Dog with Id " + adoptionDto.IdDog + " not found.");
                }

                result.AdoptionStatus = "adopted";

                unitOfWork.Adoptions.Insert(adoption);
                unitOfWork.Dogs.Update(result);

                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding adoption. Please try again later.", ex);
            }
        }


        public List<Adoption> GetAll()
        {
            try
            {
                var results = unitOfWork.Adoptions.GetAll();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving adoptions. Please check the database connection and try again.", ex);
            }
        }


    }
}
