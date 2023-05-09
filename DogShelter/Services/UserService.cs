using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;
using Microsoft.AspNetCore.Authorization;

namespace DogShelter.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        private AuthorizationService authService { get; set; }

        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public void Register(RegisterDto registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var hashedPassword = authService.HashPassword(registerData.Password);

            var user = new User
            {
                Username = registerData.Username,
                Password = hashedPassword,
                RoleId = registerData.RoleId
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

        public string Validate(LoginDto payload)
        {
            var user = unitOfWork.Users.GetByUsername(payload.Username);
            if (user == null)
            {
                return null;
            }

            var passwordFine = authService.VerifyHashedPassword(user.Password, payload.Password);

            if (passwordFine)
            {

                var role = unitOfWork.Roles.GetById(user.RoleId);

                return authService.GetToken(user, role.Type);

            }
            else
            {
                return null;
            }
        }

        public string GetRole(User user)
        {
            if (user.RoleId == 1)
            {
                return "admin";
            }
            else if (user.RoleId == 2)
            {
                return "adopter";
            }
            else
            {
                return "volunteer";
            }
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

        public bool EditUsername(UserUpdateDto payload)
        {
            if (payload == null || payload.NewUsername == null)
            {
                return false;
            }

            var result = unitOfWork.Users.GetById(payload.Id);
            if (result == null) return false;

            result.Username = payload.NewUsername;

            unitOfWork.Users.Update(result);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteUsername(int userId)
        {
            if (userId == 0)
            {
                return false;
            }

            var result = unitOfWork.Users.GetById(userId);
            if (result == null) return false;


            unitOfWork.Users.Remove(result);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
