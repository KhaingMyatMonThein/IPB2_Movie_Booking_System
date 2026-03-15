using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Theaters.DeleteTheater
{
    public class DeleteTheaterFeature
    {
        private readonly AppDbContext _context;

        public DeleteTheaterFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTheaterResponse> DeleteTheaterAsync(DeleteTheaterRequest request)
        {
            var theater = await _context.Theaters.FindAsync(request.Id);

            if (theater == null)
                return new DeleteTheaterResponse { Success = false, Message = "Theater not found" };

            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();

            return new DeleteTheaterResponse { Success = true, Message = "Theater deleted successfully" };
        }
    }
}
