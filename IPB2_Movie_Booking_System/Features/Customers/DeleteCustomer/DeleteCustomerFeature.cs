using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Customers.DeleteCustomer
{
    public class DeleteCustomerFeature
    {
        private readonly AppDbContext _context;

        public DeleteCustomerFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);

            if (customer == null)
                return new DeleteCustomerResponse { Success = false, Message = "Customer not found" };

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return new DeleteCustomerResponse { Success = true, Message = "Customer deleted successfully" };
        }
    }
}
