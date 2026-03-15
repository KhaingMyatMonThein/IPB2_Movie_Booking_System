namespace IPB2_Movie_Booking_System.Features.Bookings.GetAvailableSeats
{
    public class GetAvailableSeatsResponse
    {
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
