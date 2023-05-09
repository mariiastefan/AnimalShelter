namespace DogShelter.Services
{
    public class DonationService
    {
        private readonly UnitOfWork unitOfWork;

        public DonationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
