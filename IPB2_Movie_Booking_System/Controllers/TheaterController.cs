using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Controllers
{

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
        var feature = new Features.Theaters.GetTheaters.GetTheatersFeature(_context);
        var response = await feature.GetTheatersAsync(new Features.Theaters.GetTheaters.GetTheatersRequest());
        return Ok(response.Theaters);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTheater(Features.Theaters.CreateTheater.CreateTheaterRequest request)
    {
        var feature = new Features.Theaters.CreateTheater.CreateTheaterFeature(_context);
        var response = await feature.CreateTheaterAsync(request);
        return Ok(response.Theater);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTheater(int id, Features.Theaters.UpdateTheater.UpdateTheaterRequest request)
    {
        if (id != request.Id)
            return BadRequest();

        var feature = new Features.Theaters.UpdateTheater.UpdateTheaterFeature(_context);
        var response = await feature.UpdateTheaterAsync(request);

        if (!response.Success)
            return NotFound();

        return Ok(response.Theater);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTheater(int id)
    {
        var feature = new Features.Theaters.DeleteTheater.DeleteTheaterFeature(_context);
        var response = await feature.DeleteTheaterAsync(new Features.Theaters.DeleteTheater.DeleteTheaterRequest { Id = id });

        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Message);
    }
}
}