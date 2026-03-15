using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Customers.CreateCustomer
{
    public class CreateCustomerFeature
    {
        private readonly AppDbContext _context;

        public CreateCustomerFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CreateCustomerResponse { Customer = customer };
        }
    }
}
