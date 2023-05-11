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

            try
            {
                dogService.AddDog(payload);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while adding the dog.");
            }
        }

        [HttpGet("/get-all-dogs")]
        [AllowAnonymous]
        public ActionResult<List<Dog>> GetAll()
        {
            try
            {
                var results = dogService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the dogs: " + ex.Message);
                return BadRequest("An error occurred while retrieving the dogs.");
            }
        }

        [HttpGet("/get-dog/{dogId}")]
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

        [HttpPatch("/edit-adoption-status")]
        [AllowAnonymous]
        public ActionResult<bool> EditAdoptionStatus([FromBody] UpdateAdoptionStatusDto payload)
        {
            var result = dogService.EditAdoptionStatus(payload);

            if (!result)
            {
                return BadRequest("Adoption status could not be updated.");
            }

            return result;
        }

        [HttpPut("/edit-dog-details")]
        [AllowAnonymous]
        public ActionResult<bool> EditDogDetails([FromBody] DogDetailsUpdateDto payload)
        {
            var result = dogService.EditDogDetails(payload);

            if (!result)
            {
                return BadRequest("Dog details could not be updated.");
            }

            return result;
        }



        [HttpDelete("/delete-dog")]
        [AllowAnonymous]
        public ActionResult<bool> DeleteDog(int idDog)
        {
            var result = dogService.DeleteDog(idDog);
            if (!result)
            {
                return BadRequest("Dog could not be deleted.");
            }

            return result;

        }
    }
}
