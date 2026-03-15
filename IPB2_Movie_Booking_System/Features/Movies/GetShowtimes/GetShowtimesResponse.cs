namespace IPB2_Movie_Booking_System.Features.Movies.GetShowtimes
{
    public class GetShowtimesResponse
    {
        public List<GetShowtimesResponseItem> Showtimes { get; set; } = new();
    }

    public class GetShowtimesResponseItem
    {
        public int ShowtimeId { get; set; }
        public DateOnly? ShowDate { get; set; }
        public TimeOnly? ShowTime { get; set; }
        public decimal? Price { get; set; }
        public string? Screen { get; set; }
        public string? Theater { get; set; }
    }
}
