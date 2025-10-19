using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.DTOs;
using Hotel_Reservation_System.Repositories.GuestProfileRepository;
using Hotel_Reservation_System.Repositories.GuestRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestProfileController : ControllerBase
    {
        private readonly IGuestProfileRepo _guestProfileRepo;
        private readonly IGuestRepo _guestRepo;

        public GuestProfileController(IGuestProfileRepo guestProfileRepo, IGuestRepo guestRepo)
        {
            _guestProfileRepo = guestProfileRepo;
            _guestRepo = guestRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuestProfile(CreateGuestProfileDto dto)
        {
            if (dto == null)
                return BadRequest("There is empty data!!");

            var guest = await _guestRepo.GetGuestWithProfileById(dto.GuestId);

            if (guest == null)
                return NotFound("Guest id isn't correct, check it again");

            if (guest.Profile != null)
                return BadRequest("Guest already have a profile, can't create a new profile for it");

            var allprofiles = await _guestProfileRepo.GetAllAsync();

            if (allprofiles.Any(a => a.NationalId == dto.NationalId))
                return BadRequest("Error: the National Id must be Unique");
            

            var profile = new GuestProfile()
            {
                NationalId = dto.NationalId,
                Address = dto.Address,
                LoyaltyPoints = dto.LoyaltyPoints,
                DateOfBirth = dto.DateOfBirth,
                GuestId = dto.GuestId
            };

            await _guestProfileRepo.CreateAsync(profile);
            await _guestProfileRepo.SaveChangesAsync();


            return Ok(dto);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGuestProfile(int id)
        {
            var profile = await _guestProfileRepo.GetByIdAsync(id);

            if (profile == null)
                return NotFound("Guest profile not found");

            if (profile.GuestId > 0)
                return BadRequest("It linked to Guest, can't delete it");

            _guestProfileRepo.Delete(profile);
            await _guestProfileRepo.SaveChangesAsync();

            return NoContent();
        }
    }
}
