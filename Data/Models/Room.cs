using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }

        [Range(1, int.MaxValue), Precision(8, 3)]
        public decimal PricePerNight { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        //
        public int HotelId { get; set; }
        public  Hotel Hotel { get; set; }

        public List<Booking> Bookings { get; set; }


    }
}
