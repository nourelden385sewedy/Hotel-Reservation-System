using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.GuestProfileRepository
{
    public class GuestProfileRepo : GenericRepo<GuestProfile>, IGuestProfileRepo
    {
        public GuestProfileRepo(MyAppDbContext context) : base(context)
        {
        }
    }
}
