namespace IPB2_Movie_Booking_System.Features.Customers.DeleteCustomer
{
    public class DeleteCustomerRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
