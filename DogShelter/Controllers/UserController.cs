using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            try
            {
                var results = userService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving all users. Please try again later.");
            }
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            try
            {
                userService.Register(payload);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while registering a user. Please try again later.");
            }
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            try
            {
                var jwtToken = userService.Validate(payload);
                return Ok(new { token = jwtToken });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while validating a user login. Please try again later.");
            }
        }

        [HttpGet("/get/{userId}")]
        [AllowAnonymous]
        public ActionResult<User> GetById(int userId)
        {
            try
            {
                var result = userService.GetById(userId);

                if (result == null)
                {
                    return BadRequest("User not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the user. Please try again later.");
            }
        }

        [HttpPatch("/edit-username")]
        [AllowAnonymous]
        public ActionResult<bool> EditUsername([FromBody] UserUpdateDto userUpdateModel)
        {
            try
            {
                var result = userService.EditUsername(userUpdateModel);

                if (!result)
                {
                    return BadRequest("Account username could not be updated.");
                }

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the account username. Please try again later.");
            }
        }

        [HttpDelete("/delete-username")]
        [AllowAnonymous]
        public ActionResult<bool> DeleteUsername(int idUsername)
        {
            try
            {
                var result = userService.DeleteUsername(idUsername);

                if (!result)
                {
                    return BadRequest("Account could not be deleted.");
                }

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the account. Please try again later.");
            }

        }
    }
}
