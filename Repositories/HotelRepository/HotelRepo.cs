using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.HotelRepository
{
    public class HotelRepo : GenericRepo<Hotel>, IHotelRepo
    {
        public HotelRepo(MyAppDbContext context) : base(context)
        {
        }
    }
}
