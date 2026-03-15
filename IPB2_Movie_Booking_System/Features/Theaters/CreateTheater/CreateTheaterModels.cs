using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Theaters.CreateTheater
{
    public class CreateTheaterRequest
    {
        public string? TheaterName { get; set; }
        public string? Location { get; set; }
    }

    public class CreateTheaterResponse
    {
        public Theater Theater { get; set; } = new();
    }
}
