using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            adoptionService.AddAdoption(payload);
            return Ok();
        }

        [HttpGet("/get-all-adoptions")]
        [AllowAnonymous]
        public ActionResult<List<Adoption>> GetAllAdoptions()
        {
            var results = adoptionService.GetAll();

            return Ok(results);
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
