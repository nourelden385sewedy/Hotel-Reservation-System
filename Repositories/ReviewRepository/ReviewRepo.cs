using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.ReviewRepository
{
    public class ReviewRepo : GenericRepo<Review>, IReviewRepo
    {
        public ReviewRepo(MyAppDbContext context) : base(context)
        {
        }
    }
}
