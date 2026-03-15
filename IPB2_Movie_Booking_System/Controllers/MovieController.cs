using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var feature = new Features.Movies.GetMovies.GetMoviesFeature(_context);
            var response = await feature.GetMoviesAsync(new Features.Movies.GetMovies.GetMoviesRequest());
            return Ok(response.Movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var feature = new Features.Movies.GetMovieById.GetMovieByIdFeature(_context);
            var response = await feature.GetMovieByIdAsync(new Features.Movies.GetMovieById.GetMovieByIdRequest { Id = id });

            if (response.Movie == null)
                return NotFound();

            return Ok(response.Movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(Features.Movies.CreateMovie.CreateMovieRequest request)
        {
            var feature = new Features.Movies.CreateMovie.CreateMovieFeature(_context);
            var response = await feature.CreateMovieAsync(request);
            return Ok(response.Movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Features.Movies.UpdateMovie.UpdateMovieRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var feature = new Features.Movies.UpdateMovie.UpdateMovieFeature(_context);
            var response = await feature.UpdateMovieAsync(request);

            if (!response.Success)
                return NotFound();

            return Ok(response.Movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var feature = new Features.Movies.DeleteMovie.DeleteMovieFeature(_context);
            var response = await feature.DeleteMovieAsync(new Features.Movies.DeleteMovie.DeleteMovieRequest { Id = id });

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }
}