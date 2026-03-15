using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var feature = new Features.Customers.GetCustomers.GetCustomersFeature(_context);
            var response = await feature.GetCustomersAsync(new Features.Customers.GetCustomers.GetCustomersRequest());
            return Ok(response.Customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Features.Customers.CreateCustomer.CreateCustomerRequest request)
        {
            var feature = new Features.Customers.CreateCustomer.CreateCustomerFeature(_context);
            var response = await feature.CreateCustomerAsync(request);
            return Ok(response.Customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Features.Customers.UpdateCustomer.UpdateCustomerRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var feature = new Features.Customers.UpdateCustomer.UpdateCustomerFeature(_context);
            var response = await feature.UpdateCustomerAsync(request);

            if (!response.Success)
                return NotFound();

            return Ok(response.Customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var feature = new Features.Customers.DeleteCustomer.DeleteCustomerFeature(_context);
            var response = await feature.DeleteCustomerAsync(new Features.Customers.DeleteCustomer.DeleteCustomerRequest { Id = id });

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }
}