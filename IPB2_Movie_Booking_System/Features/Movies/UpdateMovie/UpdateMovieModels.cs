using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Movies.UpdateMovie
{
    public class UpdateMovieRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Rating { get; set; }
        public DateOnly? ReleaseDate { get; set; }
    }

    public class UpdateMovieResponse
    {
        public bool Success { get; set; }
        public Movie? Movie { get; set; }
    }
}
