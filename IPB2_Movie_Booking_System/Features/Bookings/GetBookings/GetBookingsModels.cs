using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Bookings.GetBookings
{
    public class GetBookingsRequest
    {
    }

    public class GetBookingsResponse
    {
        public List<Booking> Bookings { get; set; } = new();
    }
}
