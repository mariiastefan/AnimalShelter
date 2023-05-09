namespace DogShelter.Services
{
    public class AdoptionService
    {
        private readonly UnitOfWork unitOfWork;

        public AdoptionService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
