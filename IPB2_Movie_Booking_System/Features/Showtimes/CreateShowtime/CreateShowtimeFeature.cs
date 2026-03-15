using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Showtimes.CreateShowtime
{
    public class CreateShowtimeFeature
    {
        private readonly AppDbContext _context;

        public CreateShowtimeFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateShowtimeResponse> CreateShowtimeAsync(CreateShowtimeRequest request)
        {
            var showtime = new Showtime
            {
                MovieId = request.MovieId,
                ScreenId = request.ScreenId,
                ShowDate = request.ShowDate,
                ShowTime = request.ShowTime,
                Price = request.Price
            };

            _context.Showtimes.Add(showtime);
            await _context.SaveChangesAsync();

            return new CreateShowtimeResponse { Showtime = showtime };
        }
    }
}
