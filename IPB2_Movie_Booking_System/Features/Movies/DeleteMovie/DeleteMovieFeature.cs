using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Movies.DeleteMovie
{
    public class DeleteMovieFeature
    {
        private readonly AppDbContext _context;

        public DeleteMovieFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteMovieResponse> DeleteMovieAsync(DeleteMovieRequest request)
        {
            var movie = await _context.Movies.FindAsync(request.Id);

            if (movie == null)
                return new DeleteMovieResponse { Success = false, Message = "Movie not found" };

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return new DeleteMovieResponse { Success = true, Message = "Movie deleted successfully" };
        }
    }
}
