using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Screens.CreateScreen
{
    public class CreateScreenRequest
    {
        public int? TheaterId { get; set; }
        public string? ScreenName { get; set; }
        public int? TotalSeats { get; set; }
    }

    public class CreateScreenResponse
    {
        public Screen Screen { get; set; } = new();
    }
}
