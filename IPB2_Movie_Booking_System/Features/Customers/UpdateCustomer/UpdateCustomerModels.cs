using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Customers.UpdateCustomer
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    public class UpdateCustomerResponse
    {
        public bool Success { get; set; }
        public Customer? Customer { get; set; }
    }
}
