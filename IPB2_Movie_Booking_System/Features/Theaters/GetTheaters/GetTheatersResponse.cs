using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Theaters.GetTheaters
{
    public class GetTheatersResponse
    {
        public List<Theater> Theaters { get; set; } = new();
    }
}
