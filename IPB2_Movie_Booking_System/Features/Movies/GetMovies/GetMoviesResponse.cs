using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Movies.GetMovies
{
    public class GetMoviesResponse
    {
        public List<Movie> Movies { get; set; } = new();
    }
}
