using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Showtimes.GetShowtimes
{
    public class GetShowtimesFeature
    {
        private readonly AppDbContext _context;

        public GetShowtimesFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetShowtimesResponse> GetShowtimesAsync(GetShowtimesRequest request)
        {
            var showtimes = await _context.Showtimes
                .Include(x => x.Movie)
                .Include(x => x.Screen)
                .ThenInclude(x => x.Theater)
                .ToListAsync();

            return new GetShowtimesResponse { Showtimes = showtimes };
        }
    }
}
