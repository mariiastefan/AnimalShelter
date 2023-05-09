using DogShelter.DTOs;
using DogShelter.Models;

namespace DogShelter.Mapping
{
    public static class UserMappingExtensions
    {
        public static UserDto ToUserDto(this User user)
        {
            if (user == null) return null;

            var result = new UserDto();
            result.Id = user.Id;
            result.Username = user.Username;
            result.RoleId = user.RoleId;
            result.Role = user.Role;

            return result;
        }
    }
}
