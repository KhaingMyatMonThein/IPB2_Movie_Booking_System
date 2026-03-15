using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Showtimes.CreateShowtime
{
    public class CreateShowtimeRequest
    {
        public int? MovieId { get; set; }
        public int? ScreenId { get; set; }
        public DateOnly? ShowDate { get; set; }
        public TimeOnly? ShowTime { get; set; }
        public decimal? Price { get; set; }
    }

    public class CreateShowtimeResponse
    {
        public Showtime Showtime { get; set; } = new();
    }
}
