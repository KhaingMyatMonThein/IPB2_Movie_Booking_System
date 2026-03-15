namespace IPB2_Movie_Booking_System.Features.Bookings.BookTicket
{
    public class BookTicketRequest
    {
        public int? CustomerId { get; set; }
        public int? ShowtimeId { get; set; }
        public int? SeatsBooked { get; set; }
    }
}
