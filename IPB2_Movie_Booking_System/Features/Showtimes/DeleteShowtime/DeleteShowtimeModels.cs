namespace IPB2_Movie_Booking_System.Features.Showtimes.DeleteShowtime
{
    public class DeleteShowtimeRequest
    {
        public int Id { get; set; }
    }

    public class DeleteShowtimeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
