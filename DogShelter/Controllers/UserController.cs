using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("controller")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserService userService { get; set; }

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("/get-all")]
        [AllowAnonymous]
        public ActionResult<List<User>> GetAll()
        {
            var results = userService.GetAll();

            return Ok(results);
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            userService.Register(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = userService.Validate(payload);

            return Ok(new { token = jwtToken });
        }

        [HttpGet("/get/{userId}")]
        [AllowAnonymous]
        public ActionResult<User> GetById(int userId)
        {
            var result = userService.GetById(userId);

            if (result == null)
            {
                return BadRequest("User not found");
            }

            return Ok(result);
        }

        [HttpPatch("/edit-username")]
        [AllowAnonymous]
        public ActionResult<bool> EditUsername([FromBody] UserUpdateDto userUpdateModel)
        {
            var result = userService.EditUsername(userUpdateModel);

            if (!result)
            {
                return BadRequest("Account username could not be updated.");
            }

            return result;
        }

        [HttpPatch("/delete-username")]
        [AllowAnonymous]
        public ActionResult<bool> DeleteUsername(int idUsername)
        {
            var result = userService.DeleteUsername(idUsername);
            if (!result)
            {
                return BadRequest("Account could not be delete.");
            }

            return result;

        }
    }
}
