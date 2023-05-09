using Microsoft.AspNetCore.Authorization;

namespace DogShelter.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;


        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
