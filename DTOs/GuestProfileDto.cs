using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.DTOs
{
    public class GuestProfileDto
    {
        public int Id { get; set; }

        [Required] //Unique
        public string NationalId { get; set; }
        public int LoyaltyPoints { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
