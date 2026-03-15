using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Showtimes.GetShowtimes
{
    public class GetShowtimesRequest
    {
    }

    public class GetShowtimesResponse
    {
        public List<Showtime> Showtimes { get; set; } = new();
    }
}
