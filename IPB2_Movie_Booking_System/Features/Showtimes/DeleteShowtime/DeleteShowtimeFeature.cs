using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Showtimes.DeleteShowtime
{
    public class DeleteShowtimeFeature
    {
        private readonly AppDbContext _context;

        public DeleteShowtimeFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteShowtimeResponse> DeleteShowtimeAsync(DeleteShowtimeRequest request)
        {
            var showtime = await _context.Showtimes.FindAsync(request.Id);

            if (showtime == null)
                return new DeleteShowtimeResponse { Success = false, Message = "Showtime not found" };

            _context.Showtimes.Remove(showtime);
            await _context.SaveChangesAsync();

            return new DeleteShowtimeResponse { Success = true, Message = "Showtime deleted successfully" };
        }
    }
}
