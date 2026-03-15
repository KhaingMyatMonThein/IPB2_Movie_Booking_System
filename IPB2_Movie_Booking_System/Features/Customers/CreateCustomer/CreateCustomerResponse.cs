using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Customers.CreateCustomer
{
    public class CreateCustomerResponse
    {
        public Customer Customer { get; set; } = new();
    }
}
