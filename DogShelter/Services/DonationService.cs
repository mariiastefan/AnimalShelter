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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the donation: " + ex.Message);
                throw;
            }

        }


        public List<Donation> GetAll()
        {
            try
            {
                var results = unitOfWork.Donations.GetAll();
                return results;
            }
            catch (Exception ex)
            { 
                Console.WriteLine("An error occurred while retrieving the donations: " + ex.Message);
                throw; 
            }
        }
    }
}
