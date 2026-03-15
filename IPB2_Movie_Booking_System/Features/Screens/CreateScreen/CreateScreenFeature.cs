using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Screens.CreateScreen
{
    public class CreateScreenFeature
    {
        private readonly AppDbContext _context;

        public CreateScreenFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateScreenResponse> CreateScreenAsync(CreateScreenRequest request)
        {
            var screen = new Screen
            {
                TheaterId = request.TheaterId,
                ScreenName = request.ScreenName,
                TotalSeats = request.TotalSeats
            };

            _context.Screens.Add(screen);
            await _context.SaveChangesAsync();

            return new CreateScreenResponse { Screen = screen };
        }
    }
}
