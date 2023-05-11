using DogShelter.DTOs;
using DogShelter.Models;
using DogShelter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.Controllers
{
    [ApiController]
    [Route("controller")]
    public class DonationController: ControllerBase
    {
        private DonationService donationService { get; set; }

        public DonationController(DonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpPost("/addDonation")]
        [AllowAnonymous]
        public IActionResult AddDonation(DonationDto payload)
        {
            donationService.AddDonation(payload);
            return Ok();
        }

        [HttpGet("/get-all-donations")]
        [AllowAnonymous]
        public ActionResult<List<Donation>> GetAllAdoptions()
        {
            var results = donationService.GetAll();

            return Ok(results);
        }
    }
}
