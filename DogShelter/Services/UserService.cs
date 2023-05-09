using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;
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

        public void Register(RegisterDto registerData)
        {
            if (registerData == null)
            {
                return;
            }


            var user = new User
            {
                Username = registerData.Username,
                Password = registerData.Password,
                RoleId = registerData.RoleId
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

        public string Validate(LoginDto payload)
        {
            var user = unitOfWork.Users.GetByUsername(payload.Username);

            return null;
        }

        public string GetRole(User user)
        {
            return null;
        }

        public List<User> GetAll()
        {
            var results = unitOfWork.Users.GetAll();

            return results;
        }

        public UserDto GetById(int userId)
        {
            var user = unitOfWork.Users.GetById(userId);

            var result = user.ToUserDto();

            return result;
        }
    }
}
