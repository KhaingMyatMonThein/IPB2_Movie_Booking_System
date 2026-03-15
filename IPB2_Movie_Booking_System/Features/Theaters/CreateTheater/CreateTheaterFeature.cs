using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Theaters.CreateTheater
{
    public class CreateTheaterFeature
    {
        private readonly AppDbContext _context;

        public CreateTheaterFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateTheaterResponse> CreateTheaterAsync(CreateTheaterRequest request)
        {
            var theater = new Theater
            {
                TheaterName = request.TheaterName,
                Location = request.Location
            };

            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();

            return new CreateTheaterResponse { Theater = theater };
        }
    }
}
