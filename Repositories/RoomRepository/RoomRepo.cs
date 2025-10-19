using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.RoomRepository
{
    public class RoomRepo : GenericRepo<Room>, IRoomRepo
    {
        public RoomRepo(MyAppDbContext context) : base(context)
        {
        }
    }
}
