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

        public Details GetById(int detailsId)
        {
            var details = unitOfWork.Details.GetById(detailsId);

            var result = details;

            return result;
        }
    }
}
