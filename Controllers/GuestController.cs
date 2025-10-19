using Hotel_Reservation_System.DTOs;
using Hotel_Reservation_System.Repositories.GuestRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepo _guestRepo;

        public GuestController(IGuestRepo guestRepo)
        {
            _guestRepo = guestRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var gf = await _guestRepo.GetAllGuestsAsync();

            if (gf.Count() == 0)
                return NotFound("There is no Guests");


            var guests = gf.Select(g => new CustomGuestDto
            {
                Id = g.Id,
                Name = g.Name,
                Email = g.Email,
                Phone = g.Phone,
                TotalAmountSpent = g.Bookings.Sum(b => b.TotalCost),
                profile = new GuestProfileDto
                {
                    Id = g.Profile.Id,
                    NationalId = g.Profile.NationalId,
                    Address = g.Profile.Address,
                    DateOfBirth = g.Profile.DateOfBirth,
                    LoyaltyPoints = g.Profile.LoyaltyPoints
                },
                //bookings = g.Bookings.Select(b => new BookingDto
                //{
                //    Id = b.Id,
                //    CheckIn = b.CheckIn,
                //    CheckOut = b.CheckOut,
                //    Status = b.Status,
                //    TotalCost = b.TotalCost
                //}).ToList(),
                reviews = g.Reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Date = r.Date,
                    Rating = r.Rating
                }).ToList()
            }).ToList();

            return Ok(guests);
        }


        [HttpGet("spending-summary")]
        public async Task<IActionResult> SpendingSummary()
        {

            var g = await _guestRepo.GetAllGuestsAsync();

            if (g.Count() == 0)
                return NotFound("There is no Guests");

            var guests =  g.Select(g => new GuestSummaryDto
            {
                Id = g.Id,
                Name= g.Name,
                TotalAmountSpent = g.Bookings.Sum(b => b.TotalCost),
                Total_Stays_Days = g.Bookings.Sum(b => (b.CheckOut -  b.CheckIn).Days)
            }).ToList();

            return Ok(guests);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {

            var g = await _guestRepo.GetByIdAsync(id);

            if (g == null)
                return NotFound("Guest not found, id not correct");

            if (g.Bookings.Any(b => b.Status == "Active"))
                return BadRequest("Can't Delete Guest Bec he have active bookings");

            _guestRepo.Delete(g);
            await _guestRepo.SaveChangesAsync();

            return NoContent();        
        }

    }
}
