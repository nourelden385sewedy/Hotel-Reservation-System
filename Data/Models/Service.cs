using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Data.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1, double.MaxValue), Precision(8, 3)]
        public decimal Price { get; set; }

        // 

        public List<Booking> Bookings { get; set; }
    }
}
