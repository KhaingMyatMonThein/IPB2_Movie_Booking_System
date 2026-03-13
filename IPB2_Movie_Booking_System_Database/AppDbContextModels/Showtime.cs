using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class Showtime
{
    public int ShowtimeId { get; set; }

    public int? MovieId { get; set; }

    public int? ScreenId { get; set; }

    public DateOnly? ShowDate { get; set; }

    public TimeOnly? ShowTime { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Movie? Movie { get; set; }

    public virtual Screen? Screen { get; set; }
}
