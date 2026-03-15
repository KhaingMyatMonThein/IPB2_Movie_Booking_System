namespace IPB2_Movie_Booking_System.Features.Movies.DeleteMovie
{
    public class DeleteMovieRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMovieResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
