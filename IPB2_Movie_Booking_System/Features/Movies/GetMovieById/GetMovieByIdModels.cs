namespace IPB2_Movie_Booking_System.Features.Movies.GetMovieById
{
    public class GetMovieByIdRequest
    {
        public int Id { get; set; }
    }

    public class GetMovieByIdResponse
    {
        public IPB2_Movie_Booking_System_Database.AppDbContextModels.Movie? Movie { get; set; }
    }
}
