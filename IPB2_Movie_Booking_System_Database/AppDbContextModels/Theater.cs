using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class Theater
{
    public int TheaterId { get; set; }

    public string? TheaterName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Screen> Screens { get; set; } = new List<Screen>();
}
