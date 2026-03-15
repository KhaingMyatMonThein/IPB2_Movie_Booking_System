namespace IPB2_Movie_Booking_System.Features.Screens.DeleteScreen
{
    public class DeleteScreenRequest
    {
        public int Id { get; set; }
    }

    public class DeleteScreenResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
