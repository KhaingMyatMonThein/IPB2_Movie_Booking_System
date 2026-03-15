using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Bookings.BookTicket
{
    public class BookTicketFeature
    {
        private readonly AppDbContext _context;

        public BookTicketFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message, int BookingId)> BookTicketAsync(BookTicketRequest request)
        {
            var showtime = await _context.Showtimes
                .Include(x => x.Screen)
                .FirstOrDefaultAsync(x => x.ShowtimeId == request.ShowtimeId);

            if (showtime == null)
                return (false, "Showtime not found", 0);

            int totalSeats = (int)(showtime.Screen?.TotalSeats ?? 0);
            int bookedSeats = await _context.Bookings
                .Where(x => x.ShowtimeId == request.ShowtimeId)
                .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

            int availableSeats = totalSeats - bookedSeats;

            if (request.SeatsBooked > availableSeats)
                return (false, "Not enough seats available", 0);

            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                ShowtimeId = request.ShowtimeId,
                SeatsBooked = request.SeatsBooked,
                BookingDate = DateTime.Now
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return (true, "Booking Successful", booking.BookingId);
        }
    }
}
