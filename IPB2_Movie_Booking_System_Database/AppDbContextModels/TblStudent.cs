using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class TblStudent
{
    public Guid StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public int Age { get; set; }

    public string MobileNumber { get; set; } = null!;

    public bool IsDelete { get; set; }
}
