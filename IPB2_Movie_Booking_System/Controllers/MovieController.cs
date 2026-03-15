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

        // GET ALL MOVIES
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        // GET MOVIE BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // CREATE MOVIE
        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        // UPDATE MOVIE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
                return BadRequest();

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        // DELETE MOVIE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok("Movie deleted successfully");
        }
    }
}