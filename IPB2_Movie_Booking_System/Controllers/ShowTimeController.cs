using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Controllers
{

[ApiController]
[Route("api/[controller]")]
public class ShowtimeController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShowtimeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetShowtimes()
    {
        var feature = new Features.Showtimes.GetShowtimes.GetShowtimesFeature(_context);
        var response = await feature.GetShowtimesAsync(new Features.Showtimes.GetShowtimes.GetShowtimesRequest());
        return Ok(response.Showtimes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShowtime(Features.Showtimes.CreateShowtime.CreateShowtimeRequest request)
    {
        var feature = new Features.Showtimes.CreateShowtime.CreateShowtimeFeature(_context);
        var response = await feature.CreateShowtimeAsync(request);
        return Ok(response.Showtime);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShowtime(int id)
    {
        var feature = new Features.Showtimes.DeleteShowtime.DeleteShowtimeFeature(_context);
        var response = await feature.DeleteShowtimeAsync(new Features.Showtimes.DeleteShowtime.DeleteShowtimeRequest { Id = id });

        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Message);
    }
}
}