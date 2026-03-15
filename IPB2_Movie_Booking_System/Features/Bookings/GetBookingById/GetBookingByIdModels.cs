using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Bookings.GetBookingById
{
    public class GetBookingByIdRequest
    {
        public int BookingId { get; set; }
    }

    public class GetBookingByIdResponse
    {
        public Booking? Booking { get; set; }
    }
}
