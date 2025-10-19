using Hotel_Reservation_System.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_System.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hotel = modelBuilder.Entity<Hotel>();
            var room = modelBuilder.Entity<Room>();
            var booking = modelBuilder.Entity<Booking>();
            var guest = modelBuilder.Entity<Guest>();
            var guestProfile = modelBuilder.Entity<GuestProfile>();
            var service = modelBuilder.Entity<Service>();
            var review = modelBuilder.Entity<Review>();

            hotel.HasIndex(x => x.Name).IsUnique();

            guestProfile.HasIndex(g => g.GuestId).IsUnique();
            guestProfile.HasIndex(g => g.NationalId).IsUnique();

            service.HasIndex(g => g.Name).IsUnique();


            guest.HasOne(g => g.Profile).WithOne(v => v.Guest).HasForeignKey<GuestProfile>(g => g.GuestId)
                .OnDelete(DeleteBehavior.Cascade);

            booking.HasMany(b => b.Services).WithMany(h => h.Bookings)
                .UsingEntity(j => j.ToTable("BookingServices"));


            guest.HasData(
                new Guest { Id = 1, Name = "Nour El den", Email = "1@gmail.com", Phone = "010" },    
                new Guest { Id = 2, Name = "Anas", Email = "2@gmail.com", Phone = "010" },    
                new Guest { Id = 3, Name = "Seif", Email = "3@gmail.com", Phone = "010" },    
                new Guest { Id = 4, Name = "Ahmed", Email = "4@gmail.com", Phone = "010" },    
                new Guest { Id = 5, Name = "Omar", Email = "5@gmail.com", Phone = "010" }    
            );

            guestProfile.HasData(
                new GuestProfile { Id = 1, NationalId = "123456789", LoyaltyPoints = 1000, Address = "Giza", DateOfBirth = new DateTime(2025,10,5), GuestId = 1 },
                new GuestProfile { Id = 2, NationalId = "123789456", LoyaltyPoints = 800, Address = "Giza", DateOfBirth = new DateTime(2025,10,5), GuestId = 2 },
                new GuestProfile { Id = 3, NationalId = "456789123", LoyaltyPoints = 1500, Address = "Cairo", DateOfBirth = new DateTime(2025,10,5), GuestId = 3 },
                new GuestProfile { Id = 4, NationalId = "321456987", LoyaltyPoints = 500, Address = "Cairo", DateOfBirth = new DateTime(2025,10,5), GuestId = 4 }
            );

            hotel.HasData(
                new Hotel { Id = 1, Name = "Hotel 1", Description = "Des 1", Location = "Cairo" },    
                new Hotel { Id = 2, Name = "Hotel 2", Description = "Des 2", Location = "Giza" } 
            );

            room.HasData(
                new Room { Id = 1, RoomNumber = "R1", Capacity = 10, IsAvailable = true, PricePerNight = 120m, HotelId = 1 },
                new Room { Id = 2, RoomNumber = "R2", Capacity = 10, IsAvailable = true, PricePerNight = 80m, HotelId = 1 },
                new Room { Id = 3, RoomNumber = "R3", Capacity = 10, IsAvailable = true, PricePerNight = 100m, HotelId = 1 },
                new Room { Id = 4, RoomNumber = "R4", Capacity = 8, IsAvailable = true, PricePerNight = 50m, HotelId = 2 },
                new Room { Id = 5, RoomNumber = "R5", Capacity = 5, IsAvailable = true, PricePerNight = 15m, HotelId = 2 },
                new Room { Id = 6, RoomNumber = "R6", Capacity = 15, IsAvailable = true, PricePerNight = 110m, HotelId = 2 }
            );

            review.HasData(
                new Review { Id = 1, Comment = "Comment 1", Date = new DateTime(2025,08,10), Rating = 4, GuestId = 1, HotelId = 1 },    
                new Review { Id = 2, Comment = "Comment 2", Date = new DateTime(2025,07,10), Rating = 3, GuestId = 1, HotelId = 1 },    
                new Review { Id = 3, Comment = "Comment 3", Date = new DateTime(2025,06,10), Rating = 4, GuestId = 1, HotelId = 1 },    
                new Review { Id = 4, Comment = "Comment 4", Date = new DateTime(2025,05,10), Rating = 4, GuestId = 1, HotelId = 2 },    
                new Review { Id = 5, Comment = "Comment 5", Date = new DateTime(2025,04,10), Rating = 3, GuestId = 1, HotelId = 2 }    
            );

            service.HasData(
                new Service { Id = 1, Name = "Spa", Description = "Des", Price = 40m },    
                new Service { Id = 2, Name = "House Keeping", Description = "Des", Price = 5m },    
                new Service { Id = 3, Name = "Gym", Description = "Des", Price = 30m },    
                new Service { Id = 4, Name = "Swimming Pool", Description = "Des", Price = 50m },    
                new Service { Id = 5, Name = "Message", Description = "Des", Price = 60m }    
            );

            
            
        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestProfile> GuestProfiles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
