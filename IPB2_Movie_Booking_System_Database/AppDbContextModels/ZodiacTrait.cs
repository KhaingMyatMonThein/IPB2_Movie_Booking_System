using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class ZodiacTrait
{
    public int TraitId { get; set; }

    public int? ZodiacId { get; set; }

    public string? TraitName { get; set; }

    public int? Percentage { get; set; }
}
