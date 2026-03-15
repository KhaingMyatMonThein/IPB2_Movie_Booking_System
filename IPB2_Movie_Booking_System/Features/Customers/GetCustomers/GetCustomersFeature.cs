using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Customers.GetCustomers
{
    public class GetCustomersFeature
    {
        private readonly AppDbContext _context;

        public GetCustomersFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetCustomersResponse> GetCustomersAsync(GetCustomersRequest request)
        {
            var customers = await _context.Customers.ToListAsync();
            return new GetCustomersResponse { Customers = customers };
        }
    }
}
