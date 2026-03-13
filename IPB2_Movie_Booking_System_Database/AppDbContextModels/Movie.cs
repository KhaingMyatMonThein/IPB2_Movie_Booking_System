using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public int? DurationMinutes { get; set; }

    public string? Rating { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
