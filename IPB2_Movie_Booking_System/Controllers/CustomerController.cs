using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        private IActionResult Ok(object value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest();

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpDelete("customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}