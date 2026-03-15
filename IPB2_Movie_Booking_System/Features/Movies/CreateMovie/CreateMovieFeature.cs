using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Movies.CreateMovie
{
    public class CreateMovieFeature
    {
        private readonly AppDbContext _context;

        public CreateMovieFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateMovieResponse> CreateMovieAsync(CreateMovieRequest request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Genre = request.Genre,
                DurationMinutes = request.DurationMinutes,
                Rating = request.Rating,
                ReleaseDate = request.ReleaseDate
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return new CreateMovieResponse { Movie = movie };
        }
    }
}
