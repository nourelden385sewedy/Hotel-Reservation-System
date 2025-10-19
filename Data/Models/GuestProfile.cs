using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation_System.Data.Models
{
    public class GuestProfile
    {
        public int Id { get; set; }

        [Required] //Unique
        public string NationalId { get; set; }
        public int LoyaltyPoints { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        //
        [Required]
        public int GuestId { get; set; }
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

    }
}
