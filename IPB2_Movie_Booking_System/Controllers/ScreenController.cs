using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ScreenController : ControllerBase
{
    private readonly AppDbContext _context;

    public ScreenController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetScreens()
    {
        return Ok(await _context.Screens
            .Include(x => x.Theater)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateScreen(Screen screen)
    {
        _context.Screens.Add(screen);
        await _context.SaveChangesAsync();
        return Ok(screen);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScreen(int id)
    {
        var screen = await _context.Screens.FindAsync(id);

        if (screen == null)
            return NotFound();

        _context.Screens.Remove(screen);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}