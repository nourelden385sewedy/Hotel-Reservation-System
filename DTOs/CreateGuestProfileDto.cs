using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.DTOs
{
    public class CreateGuestProfileDto
    {
        [Required] //Unique
        public string NationalId { get; set; }
        public int LoyaltyPoints { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; } = DateTime.Now.AddYears(18);
        public int GuestId { get; set; }

    }
}
