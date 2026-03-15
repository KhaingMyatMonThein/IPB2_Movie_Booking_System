namespace IPB2_Movie_Booking_System.Features.Theaters.DeleteTheater
{
    public class DeleteTheaterRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTheaterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
