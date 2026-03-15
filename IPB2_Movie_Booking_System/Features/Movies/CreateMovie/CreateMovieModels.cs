using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Movies.CreateMovie
{
    public class CreateMovieRequest
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Rating { get; set; }
        public DateOnly? ReleaseDate { get; set; }
    }

    public class CreateMovieResponse
    {
        public Movie Movie { get; set; } = new();
    }
}
