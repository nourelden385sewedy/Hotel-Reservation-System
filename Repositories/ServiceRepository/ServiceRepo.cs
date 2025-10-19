using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.ServiceRepository
{
    public class ServiceRepo : GenericRepo<Service>, IServiceRepo
    {
        public ServiceRepo(MyAppDbContext context) : base(context)
        {
        }
    }
}
