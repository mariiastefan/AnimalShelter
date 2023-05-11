using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AdoptionController : ControllerBase
    {
        private AdoptionService adoptionService { get; set; }

        public AdoptionController(AdoptionService adoptionService)
        {
            this.adoptionService = adoptionService;
        }

        [HttpPost("/addAdoption")]
        [AllowAnonymous]
        public IActionResult AddAdoption(AdoptionDto payload)
        {
            try
            {
                adoptionService.AddAdoption(payload);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding adoption. Please try again later.");
            }
        }

        [HttpGet("/get-all-adoptions")]
        [AllowAnonymous]
        public ActionResult<List<Adoption>> GetAllAdoptions()
        {
            try
            {
                var results = adoptionService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving adoptions. Please try again later.");
            }
        }

        //[HttpGet("/get-adoption/{adoptionId}")]
        //public ActionResult<Adoption> GetAdoptionById(int adoptionId)
        //{
        //    var result = adoptionService.GetAdoptionById(adoptionId);

        //    if (result == null)
        //    {
        //        return BadRequest("Adoption not found");
        //    }

        //    return Ok(result);
        //}
    }
}
