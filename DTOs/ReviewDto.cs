using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
