using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Theaters.GetTheaters
{
    public class GetTheatersFeature
    {
        private readonly AppDbContext _context;

        public GetTheatersFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetTheatersResponse> GetTheatersAsync(GetTheatersRequest request)
        {
            var theaters = await _context.Theaters.ToListAsync();
            return new GetTheatersResponse { Theaters = theaters };
        }
    }
}
