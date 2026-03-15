using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Theaters.UpdateTheater
{
    public class UpdateTheaterRequest
    {
        public int Id { get; set; }
        public string? TheaterName { get; set; }
        public string? Location { get; set; }
    }

    public class UpdateTheaterResponse
    {
        public bool Success { get; set; }
        public Theater? Theater { get; set; }
    }
}
