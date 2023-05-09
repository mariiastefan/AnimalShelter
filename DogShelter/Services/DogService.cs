namespace DogShelter.Services
{
    public class DogService
    {
        private readonly UnitOfWork unitOfWork;
        public DogService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
