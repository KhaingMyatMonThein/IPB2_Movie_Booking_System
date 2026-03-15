using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Screens.GetScreens
{
    public class GetScreensRequest
    {
    }

    public class GetScreensResponse
    {
        public List<Screen> Screens { get; set; } = new();
    }
}
