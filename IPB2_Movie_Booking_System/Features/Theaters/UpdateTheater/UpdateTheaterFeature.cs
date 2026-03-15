using IPB2_Movie_Booking_System_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System.Features.Theaters.UpdateTheater
{
    public class UpdateTheaterFeature
    {
        private readonly AppDbContext _context;

        public UpdateTheaterFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateTheaterResponse> UpdateTheaterAsync(UpdateTheaterRequest request)
        {
            var theater = await _context.Theaters.FindAsync(request.Id);
            if (theater == null)
                return new UpdateTheaterResponse { Success = false };

            theater.TheaterName = request.TheaterName;
            theater.Location = request.Location;

            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new UpdateTheaterResponse { Success = true, Theater = theater };
        }
    }
}
