using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var showtimes = await _context.Showtimes
            .Include(x => x.Movie)
            .Include(x => x.Screen)
            .ThenInclude(x => x.Theater)
            .ToListAsync();

        return Ok(showtimes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShowtime(Showtime showtime)
    {
        _context.Showtimes.Add(showtime);
        await _context.SaveChangesAsync();
        return Ok(showtime);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShowtime(int id)
    {
        var showtime = await _context.Showtimes.FindAsync(id);

        if (showtime == null)
            return NotFound();

        _context.Showtimes.Remove(showtime);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}