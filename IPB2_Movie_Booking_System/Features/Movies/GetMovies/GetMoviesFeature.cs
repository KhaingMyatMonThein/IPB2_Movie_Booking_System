using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Movies.GetMovies
{
    public class GetMoviesFeature
    {
        private readonly AppDbContext _context;

        public GetMoviesFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetMoviesResponse> GetMoviesAsync(GetMoviesRequest request)
        {
            var movies = await _context.Movies.ToListAsync();
            return new GetMoviesResponse { Movies = movies };
        }
    }
}
