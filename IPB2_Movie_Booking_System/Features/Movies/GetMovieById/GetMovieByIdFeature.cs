using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Movies.GetMovieById
{
    public class GetMovieByIdFeature
    {
        private readonly AppDbContext _context;

        public GetMovieByIdFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdResponse> GetMovieByIdAsync(GetMovieByIdRequest request)
        {
            var movie = await _context.Movies.FindAsync(request.Id);
            return new GetMovieByIdResponse { Movie = movie };
        }
    }
}
