using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Controllers
{

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
        var feature = new Features.Screens.GetScreens.GetScreensFeature(_context);
        var response = await feature.GetScreensAsync(new Features.Screens.GetScreens.GetScreensRequest());
        return Ok(response.Screens);
    }

    [HttpPost]
    public async Task<IActionResult> CreateScreen(Features.Screens.CreateScreen.CreateScreenRequest request)
    {
        var feature = new Features.Screens.CreateScreen.CreateScreenFeature(_context);
        var response = await feature.CreateScreenAsync(request);
        return Ok(response.Screen);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScreen(int id)
    {
        var feature = new Features.Screens.DeleteScreen.DeleteScreenFeature(_context);
        var response = await feature.DeleteScreenAsync(new Features.Screens.DeleteScreen.DeleteScreenRequest { Id = id });

        if (!response.Success)
            return NotFound(response.Message);

        return Ok(response.Message);
    }
}
}