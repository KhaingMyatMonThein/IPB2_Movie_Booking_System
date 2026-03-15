using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Theaters.GetScreens
{
    public class GetScreensFeature
    {
        private readonly AppDbContext _context;

        public GetScreensFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetScreensResponse> GetScreensAsync(GetScreensRequest request)
        {
            var screens = await _context.Screens
                .Where(x => x.TheaterId == request.TheaterId)
                .ToListAsync();

            return new GetScreensResponse { Screens = screens };
        }
    }
}
