using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieBookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovieBookingController(AppDbContext context)
        {
            _context = context;
        }

  
        [HttpGet("movies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpGet("movies/{movieId}/showtimes")]
        public async Task<IActionResult> GetShowtimesByMovie(int movieId)
        {
            var showtimes = await _context.Showtimes
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

            return Ok(showtimes);
        }


        [HttpGet("theaters")]
        public async Task<IActionResult> GetTheaters()
        {
            var theaters = await _context.Theaters.ToListAsync();
            return Ok(theaters);
        }


        [HttpGet("theaters/{theaterId}/screens")]
        public async Task<IActionResult> GetScreens(int theaterId)
        {
            var screens = await _context.Screens
                .Where(x => x.TheaterId == theaterId)
                .ToListAsync();

            return Ok(screens);
        }

  
        [HttpGet("showtimes/{showtimeId}/available-seats")]
        public async Task<IActionResult> GetAvailableSeats(int showtimeId)
        {
            var showtime = await _context.Showtimes
                .Include(x => x.Screen)
                .FirstOrDefaultAsync(x => x.ShowtimeId == showtimeId);

            if (showtime == null)
                return NotFound("Showtime not found");

            int totalSeats = (int)showtime.Screen.TotalSeats;

            int bookedSeats = await _context.Bookings
                .Where(x => x.ShowtimeId == showtimeId)
                .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

            int availableSeats = totalSeats - bookedSeats;

            return Ok(new
            {
                TotalSeats = totalSeats,
                BookedSeats = bookedSeats,
                AvailableSeats = availableSeats
            });
        }


        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

 
        [HttpPost("book-ticket")]
        public async Task<IActionResult> BookTicket(Booking booking)
        {
            var showtime = await _context.Showtimes
                .Include(x => x.Screen)
                .FirstOrDefaultAsync(x => x.ShowtimeId == booking.ShowtimeId);

            if (showtime == null)
                return NotFound("Showtime not found");

            int totalSeats = (int)showtime.Screen.TotalSeats;

            int bookedSeats = await _context.Bookings
                .Where(x => x.ShowtimeId == booking.ShowtimeId)
                .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

            int availableSeats = totalSeats - bookedSeats;

            if (booking.SeatsBooked > availableSeats)
                return BadRequest("Not enough seats available");

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Booking Successful",
                booking.BookingId
            });
        }

    
        [HttpGet("bookings")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Showtime)
                .ThenInclude(x => x.Movie)
                .Include(x => x.Showtime.Screen)
                .ThenInclude(x => x.Theater)
                .ToListAsync();

            return Ok(bookings);
        }


        [HttpGet("bookings/{bookingId}")]
        public async Task<IActionResult> GetBooking(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Showtime)
                .ThenInclude(x => x.Movie)
                .Include(x => x.Showtime.Screen)
                .ThenInclude(x => x.Theater)
                .FirstOrDefaultAsync(x => x.BookingId == bookingId);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }
    }
}