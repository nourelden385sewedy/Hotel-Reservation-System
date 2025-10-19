using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.Repositories.BookingRepository;
using Hotel_Reservation_System.Repositories.GenericRepository;
using Hotel_Reservation_System.Repositories.GuestProfileRepository;
using Hotel_Reservation_System.Repositories.GuestRepository;
using Hotel_Reservation_System.Repositories.HotelRepository;
using Hotel_Reservation_System.Repositories.ReviewRepository;
using Hotel_Reservation_System.Repositories.RoomRepository;
using Hotel_Reservation_System.Repositories.ServiceRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 1. DbContext
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("School")));

// 2. Repos
builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IGuestRepo, GuestRepo>();
builder.Services.AddScoped<IGuestProfileRepo, GuestProfileRepo>();
builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
builder.Services.AddScoped<IHotelRepo, HotelRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
