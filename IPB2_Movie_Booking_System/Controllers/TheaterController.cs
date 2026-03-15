using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TheaterController : ControllerBase
{
    private readonly AppDbContext _context;

    public TheaterController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTheaters()
    {
        return Ok(await _context.Theaters.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTheater(Theater theater)
    {
        _context.Theaters.Add(theater);
        await _context.SaveChangesAsync();
        return Ok(theater);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTheater(int id, Theater theater)
    {
        if (id != theater.TheaterId)
            return BadRequest();

        _context.Entry(theater).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(theater);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTheater(int id)
    {
        var theater = await _context.Theaters.FindAsync(id);

        if (theater == null)
            return NotFound();

        _context.Theaters.Remove(theater);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}