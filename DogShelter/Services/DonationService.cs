using DogShelter.DTOs;
using DogShelter.Models;

namespace DogShelter.Services
{
    public class DonationService
    {
        private readonly UnitOfWork unitOfWork;

        public DonationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddDonation(DonationDto donationDto)
        {
            if (donationDto == null)
            {
                return;
            }
            var donation = new Donation
            {
                
                IdUser = donationDto.IdUser,
                Amount = donationDto.Amount,
                DonationDate = donationDto.DonationDate

            };

            unitOfWork.Donations.Insert(donation);
            unitOfWork.SaveChanges();

        }


        public List<Donation> GetAll()
        {
            var results = unitOfWork.Donations.GetAll();

            return results;
        }
    }
}
