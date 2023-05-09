using DogShelter.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private UserService userService { get; set; }
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

    }
}
