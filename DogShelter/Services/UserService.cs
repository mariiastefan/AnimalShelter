using DogShelter.DTOs;
using DogShelter.Mapping;
using DogShelter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

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
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding user. Please try again later.", ex);
            }
        }

        public string Validate(LoginDto payload)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while validating the user");
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
            try
            {
                var results = unitOfWork.Users.GetAll();
                return results;
            }
            catch (Exception ex)
            {
                return new List<User> { new User { Username = "Error retrieving users: " + ex.Message } };
            }
        }

        public UserDto GetById(int userId)
        {
            try
            {
                var user = unitOfWork.Users.GetById(userId);

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var result = user.ToUserDto();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
        }

        public bool EditUsername(UserUpdateDto payload)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while editing the username.", ex);
            }
        }

        public bool DeleteUsername(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the username.", ex);
            }
        }
    }
}
