using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Movies.UpdateMovie
{
    public class UpdateMovieFeature
    {
        private readonly AppDbContext _context;

        public UpdateMovieFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateMovieResponse> UpdateMovieAsync(UpdateMovieRequest request)
        {
            var movie = await _context.Movies.FindAsync(request.Id);
            if (movie == null)
                return new UpdateMovieResponse { Success = false };

            movie.Title = request.Title;
            movie.Genre = request.Genre;
            movie.DurationMinutes = request.DurationMinutes;
            movie.Rating = request.Rating;
            movie.ReleaseDate = request.ReleaseDate;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new UpdateMovieResponse { Success = true, Movie = movie };
        }
    }
}
