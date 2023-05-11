using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;
using DogShelter.Repositories;

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

            result.AdoptionStatus = "adopted";

            unitOfWork.Adoptions.Insert(adoption);
            unitOfWork.Dogs.Update(result);

            unitOfWork.SaveChanges();

        }

    
    public List<Adoption> GetAll()
    {
        var results = unitOfWork.Adoptions.GetAll();

        return results;
    }


    }
}
