using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Customers.UpdateCustomer
{
    public class UpdateCustomerFeature
    {
        private readonly AppDbContext _context;

        public UpdateCustomerFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
                return new UpdateCustomerResponse { Success = false };

            customer.FullName = request.FullName;
            customer.Phone = request.Phone;
            customer.Email = request.Email;

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new UpdateCustomerResponse { Success = true, Customer = customer };
        }
    }
}
