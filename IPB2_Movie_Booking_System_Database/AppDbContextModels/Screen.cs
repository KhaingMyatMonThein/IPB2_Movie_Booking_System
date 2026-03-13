using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class Screen
{
    public int ScreenId { get; set; }

    public int? TheaterId { get; set; }

    public string? ScreenName { get; set; }

    public int? TotalSeats { get; set; }

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual Theater? Theater { get; set; }
}
