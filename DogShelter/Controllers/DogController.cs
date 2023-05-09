using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("controller")]
    [Authorize]
    public class DogController : ControllerBase
    {
        private DogService dogService { get; set; }

        public DogController(DogService dogService)
        {
            this.dogService = dogService;
        }

        [HttpPost("/addDog")]
        [AllowAnonymous]
        public IActionResult AddDog(AddDogDto payload)
        {
            dogService.AddDog(payload);
            return Ok();
        }

        [HttpGet("/get-all")]
        [AllowAnonymous]
        public ActionResult<List<Dog>> GetAll()
        {
            var results = dogService.GetAll();

            return Ok(results);
        }

        [HttpGet("/get/{dogId}")]
        [AllowAnonymous]
        public ActionResult<Dog> GetById(int dogId)
        {
            var result = dogService.GetById(dogId);

            if (result == null)
            {
                return BadRequest("Dog not found");
            }

            return Ok(result);
        }

        //[HttpPatch("/edit-dogname")]
        //[AllowAnonymous]
        //public ActionResult<bool> EditDogname([FromBody] DogUpdateDto dogUpdateModel)
        //{
        //    var result = dogService.EditDogname(dogUpdateModel);

        //    if (!result)
        //    {
        //        return BadRequest("Account dogname could not be updated.");
        //    }

        //    return result;
        //}

        [HttpDelete("/delete-dog")]
        [AllowAnonymous]
        public ActionResult<bool> DeleteDog(int idDog)
        {
            var result = dogService.DeleteDog(idDog);
            if (!result)
            {
                return BadRequest("Dog could not be delete.");
            }

            return result;

        }
    }
}
