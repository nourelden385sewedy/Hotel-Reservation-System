using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Data.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        //

        public GuestProfile Profile { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
