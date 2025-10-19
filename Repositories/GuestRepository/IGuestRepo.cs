using Hotel_Reservation_System.Data.Models;
using Hotel_Reservation_System.Repositories.GenericRepository;

namespace Hotel_Reservation_System.Repositories.GuestRepository
{
    public interface IGuestRepo : IGenericRepo<Guest>
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest?> GetGuestByIdAsync(int id);

        Task<Guest?> GetGuestWithProfileById(int id);
    }
}
