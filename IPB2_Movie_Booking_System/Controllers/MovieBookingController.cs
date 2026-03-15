using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using IPB2_Movie_Booking_System.Features;

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
            var feature = new Features.Movies.GetMovies.GetMoviesFeature(_context);
            var response = await feature.GetMoviesAsync(new Features.Movies.GetMovies.GetMoviesRequest());
            return Ok(response.Movies);
        }

        [HttpGet("movies/{movieId}/showtimes")]
        public async Task<IActionResult> GetShowtimesByMovie(int movieId)
        {
            var feature = new Features.Movies.GetShowtimes.GetShowtimesFeature(_context);
            var response = await feature.GetShowtimesAsync(new Features.Movies.GetShowtimes.GetShowtimesRequest { MovieId = movieId });
            return Ok(response.Showtimes);
        }


        [HttpGet("theaters")]
        public async Task<IActionResult> GetTheaters()
        {
            var feature = new Features.Theaters.GetTheaters.GetTheatersFeature(_context);
            var response = await feature.GetTheatersAsync(new Features.Theaters.GetTheaters.GetTheatersRequest());
            return Ok(response.Theaters);
        }


        [HttpGet("theaters/{theaterId}/screens")]
        public async Task<IActionResult> GetScreens(int theaterId)
        {
            var feature = new Features.Theaters.GetScreens.GetScreensFeature(_context);
            var response = await feature.GetScreensAsync(new Features.Theaters.GetScreens.GetScreensRequest { TheaterId = theaterId });
            return Ok(response.Screens);
        }

  
        [HttpGet("showtimes/{showtimeId}/available-seats")]
        public async Task<IActionResult> GetAvailableSeats(int showtimeId)
        {
            var feature = new Features.Bookings.GetAvailableSeats.GetAvailableSeatsFeature(_context);
            var response = await feature.GetAvailableSeatsAsync(new Features.Bookings.GetAvailableSeats.GetAvailableSeatsRequest { ShowtimeId = showtimeId });
            
            if (response == null)
                return NotFound("Showtime not found");

            return Ok(response);
        }


        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer(Features.Customers.CreateCustomer.CreateCustomerRequest request)
        {
            var feature = new Features.Customers.CreateCustomer.CreateCustomerFeature(_context);
            var response = await feature.CreateCustomerAsync(request);
            return Ok(response.Customer);
        }

 
        [HttpPost("book-ticket")]
        public async Task<IActionResult> BookTicket(Features.Bookings.BookTicket.BookTicketRequest request)
        {
            var feature = new Features.Bookings.BookTicket.BookTicketFeature(_context);
            var result = await feature.BookTicketAsync(request);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new { Message = result.Message, BookingId = result.BookingId });
        }

    
        [HttpGet("bookings")]
        public async Task<IActionResult> GetBookings()
        {
            var feature = new Features.Bookings.GetBookings.GetBookingsFeature(_context);
            var response = await feature.GetBookingsAsync(new Features.Bookings.GetBookings.GetBookingsRequest());
            return Ok(response.Bookings);
        }


        [HttpGet("bookings/{bookingId}")]
        public async Task<IActionResult> GetBooking(int bookingId)
        {
            var feature = new Features.Bookings.GetBookingById.GetBookingByIdFeature(_context);
            var response = await feature.GetBookingByIdAsync(new Features.Bookings.GetBookingById.GetBookingByIdRequest { BookingId = bookingId });

            if (response.Booking == null)
                return NotFound();

            return Ok(response.Booking);
        }
    }
}