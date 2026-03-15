using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Bookings.GetAvailableSeats
{
    public class GetAvailableSeatsFeature
    {
        private readonly AppDbContext _context;

        public GetAvailableSeatsFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAvailableSeatsResponse?> GetAvailableSeatsAsync(GetAvailableSeatsRequest request)
        {
            var showtime = await _context.Showtimes
                .Include(x => x.Screen)
                .FirstOrDefaultAsync(x => x.ShowtimeId == request.ShowtimeId);

            if (showtime == null)
                return null;

            int totalSeats = (int)(showtime.Screen?.TotalSeats ?? 0);

            int bookedSeats = await _context.Bookings
                .Where(x => x.ShowtimeId == request.ShowtimeId)
                .SumAsync(x => (int?)x.SeatsBooked) ?? 0;

            int availableSeats = totalSeats - bookedSeats;

            return new GetAvailableSeatsResponse
            {
                TotalSeats = totalSeats,
                BookedSeats = bookedSeats,
                AvailableSeats = availableSeats
            };
        }
    }
}
