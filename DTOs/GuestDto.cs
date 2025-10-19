using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.DTOs
{
    public class GuestDto
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }

    public class CustomGuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public GuestProfileDto profile { get; set; }
        public List<BookingDto> bookings { get; set; } = new List<BookingDto>();
        public List<ReviewDto> reviews { get; set; } = new List<ReviewDto>();

    }

    public class GuestSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public int Total_Stays_Days {  get; set; }
    }
}
