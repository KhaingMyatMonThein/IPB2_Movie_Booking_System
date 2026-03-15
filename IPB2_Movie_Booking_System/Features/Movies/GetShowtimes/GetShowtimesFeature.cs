using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Movies.GetShowtimes
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
                .Where(x => x.MovieId == request.MovieId)
                .Select(x => new GetShowtimesResponseItem
                {
                    ShowtimeId = x.ShowtimeId,
                    ShowDate = x.ShowDate,
                    ShowTime = x.ShowTime,
                    Price = x.Price,
                    Screen = x.Screen.ScreenName,
                    Theater = x.Screen.Theater.TheaterName
                })
                .ToListAsync();

            return new GetShowtimesResponse { Showtimes = showtimes };
        }
    }
}
