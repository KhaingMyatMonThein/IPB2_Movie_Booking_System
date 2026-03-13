using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? CustomerId { get; set; }

    public int? ShowtimeId { get; set; }

    public int? SeatsBooked { get; set; }

    public DateTime? BookingDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Showtime? Showtime { get; set; }
}
