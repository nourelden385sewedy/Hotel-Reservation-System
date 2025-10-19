using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Data.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required] // Unique
        public string Name { get; set; }
        public string Location { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Nav

        public List<Room> Rooms { get; set; }
        public List<Review> Reviews { get; set; }
        
    }
}
