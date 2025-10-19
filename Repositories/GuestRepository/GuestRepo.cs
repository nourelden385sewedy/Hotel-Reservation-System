using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_System.Repositories.GuestRepository
{
    public class GuestRepo : GenericRepo<Guest>, IGuestRepo
    {
        public GuestRepo(MyAppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _context.Guests
                .Include(g => g.Profile)
                .Include(g => g.Bookings)
                .Include(r => r.Reviews)
                .ToListAsync();
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            return await _context.Guests.Include(b => b.Bookings)
                .FirstOrDefaultAsync(g => g.Id == id );
        }

        public async Task<Guest?> GetGuestWithProfileById(int id)
        {
            return await _context.Guests.Include(g => g.Profile)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
