using IPB2_Movie_Booking_System_Database.AppDbContextModels;

namespace IPB2_Movie_Booking_System.Features.Screens.DeleteScreen
{
    public class DeleteScreenFeature
    {
        private readonly AppDbContext _context;

        public DeleteScreenFeature(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteScreenResponse> DeleteScreenAsync(DeleteScreenRequest request)
        {
            var screen = await _context.Screens.FindAsync(request.Id);

            if (screen == null)
                return new DeleteScreenResponse { Success = false, Message = "Screen not found" };

            _context.Screens.Remove(screen);
            await _context.SaveChangesAsync();

            return new DeleteScreenResponse { Success = true, Message = "Screen deleted successfully" };
        }
    }
}
