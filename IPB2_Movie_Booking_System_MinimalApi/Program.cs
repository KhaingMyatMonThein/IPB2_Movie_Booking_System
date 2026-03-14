using Microsoft.EntityFrameworkCore;
using IPB2_Movie_Booking_System_Database.AppDbContextModels;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map endpoints

// Get all movies
app.MapGet("/api/movies", async (AppDbContext context) =>
{
    var movies = await context.Movies.ToListAsync();
    return Results.Ok(movies);
});

// Get showtimes by movie
app.MapGet("/api/movies/{movieId}/showtimes", async (int movieId, AppDbContext context) =>
{
    var showtimes = await context.Showtimes
        .Where(x => x.MovieId == movieId)
        .Select(x => new
        {
            x.ShowtimeId,
            x.ShowDate,
            x.ShowTime,
            x.Price,
            Screen = x.Screen.ScreenName,
            Theater = x.Screen.Theater.TheaterName
        })
        .ToListAsync();

    return Results.Ok(showtimes);
});

// Get all theaters
app.MapGet("/api/theaters", async (AppDbContext context) =>
{
    var theaters = await context.Theaters.ToListAsync();
    return Results.Ok(theaters);
});

// Get screens by theater
app.MapGet("/api/theaters/{theaterId}/screens", async (int theaterId, AppDbContext context) =>
{
    var screens = await context.Screens
        .Where(x => x.TheaterId == theaterId)
        .ToListAsync();

    return Results.Ok(screens);
});

// Get available seats
app.MapGet("/api/showtimes/{showtimeId}/available-seats", async (int showtimeId, AppDbContext context) =>
{
    var showtime = await context.Showtimes
        .Include(x => x.Screen)
        .FirstOrDefaultAsync(x => x.ShowtimeId == showtimeId);

    if (showtime == null)
        return Results.NotFound("Showtime not found");

    int totalSeats = (int)showtime.Screen.TotalSeats;
    int bookedSeats = await context.Bookings
        .Where(x => x.ShowtimeId == showtimeId)
        .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

    int availableSeats = totalSeats - bookedSeats;

    return Results.Ok(new
    {
        TotalSeats = totalSeats,
        BookedSeats = bookedSeats,
        AvailableSeats = availableSeats
    });
});

// Create customer
app.MapPost("/api/customers", async (Customer customer, AppDbContext context) =>
{
    context.Customers.Add(customer);
    await context.SaveChangesAsync();
    return Results.Ok(customer);
});

// Book ticket
app.MapPost("/api/book-ticket", async (Booking booking, AppDbContext context) =>
{
    var showtime = await context.Showtimes
        .Include(x => x.Screen)
        .FirstOrDefaultAsync(x => x.ShowtimeId == booking.ShowtimeId);

    if (showtime == null)
        return Results.NotFound("Showtime not found");

    int totalSeats = (int)showtime.Screen.TotalSeats;
    int bookedSeats = await context.Bookings
        .Where(x => x.ShowtimeId == booking.ShowtimeId)
        .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

    int availableSeats = totalSeats - bookedSeats;

    if (booking.SeatsBooked > availableSeats)
        return Results.BadRequest("Not enough seats available");

    context.Bookings.Add(booking);
    await context.SaveChangesAsync();

    return Results.Ok(new { Message = "Booking Successful", booking.BookingId });
});

// Get all bookings
app.MapGet("/api/bookings", async (AppDbContext context) =>
{
    var bookings = await context.Bookings
        .Include(x => x.Customer)
        .Include(x => x.Showtime)
        .ThenInclude(x => x.Movie)
        .Include(x => x.Showtime.Screen)
        .ThenInclude(x => x.Theater)
        .ToListAsync();

    return Results.Ok(bookings);
});

// Get booking by ID
app.MapGet("/api/bookings/{bookingId}", async (int bookingId, AppDbContext context) =>
{
    var booking = await context.Bookings
        .Include(x => x.Customer)
        .Include(x => x.Showtime)
        .ThenInclude(x => x.Movie)
        .Include(x => x.Showtime.Screen)
        .ThenInclude(x => x.Theater)
        .FirstOrDefaultAsync(x => x.BookingId == bookingId);

    if (booking == null)
        return Results.NotFound();

    return Results.Ok(booking);
});

app.Run();