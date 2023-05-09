namespace DogShelter.Services
{
    public class DetailsService
    {
        private readonly UnitOfWork unitOfWork;

        public DetailsService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
