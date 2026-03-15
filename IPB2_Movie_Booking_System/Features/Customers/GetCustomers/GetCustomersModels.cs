using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Customers.GetCustomers
{
    public class GetCustomersRequest
    {
    }

    public class GetCustomersResponse
    {
        public List<Customer> Customers { get; set; } = new();
    }
}
