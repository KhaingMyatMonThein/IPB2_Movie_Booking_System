using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Bookings.GetBookings
{
    public class GetBookingsFeature
    {
        private readonly AppDbContext _context;

        public GetBookingsFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetBookingsResponse> GetBookingsAsync(GetBookingsRequest request)
        {
            var bookings = await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Showtime)
                .ThenInclude(x => x.Movie)
                .Include(x => x.Showtime.Screen)
                .ThenInclude(x => x.Theater)
                .ToListAsync();

            return new GetBookingsResponse { Bookings = bookings };
        }
    }
}
