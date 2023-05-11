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
            try
            {
                donationService.AddDonation(payload);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while adding the donation.");
            }
        }

        [HttpGet("/get-all-donations")]
        [AllowAnonymous]
        public ActionResult<List<Donation>> GetAllDonations()
        {
            try
            {
                var results = donationService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the donations: " + ex.Message);
                return BadRequest("An error occurred while retrieving the donations.");
            }
        }
    }
}
