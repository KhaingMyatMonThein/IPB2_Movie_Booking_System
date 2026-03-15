using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Bookings.GetBookingById
{
    public class GetBookingByIdFeature
    {
        private readonly AppDbContext _context;

        public GetBookingByIdFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetBookingByIdResponse> GetBookingByIdAsync(GetBookingByIdRequest request)
        {
            var booking = await _context.Bookings
                .Include(x => x.Customer)
                .Include(x => x.Showtime)
                .ThenInclude(x => x.Movie)
                .Include(x => x.Showtime.Screen)
                .ThenInclude(x => x.Theater)
                .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);

            return new GetBookingByIdResponse { Booking = booking };
        }
    }
}
