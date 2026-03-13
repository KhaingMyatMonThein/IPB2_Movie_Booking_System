using System;
using System.Collections.Generic;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class WalletTransaction
{
    public int Id { get; set; }

    public string? TxnId { get; set; }

    public string? FromMobileNo { get; set; }

    public string? ToMobileNo { get; set; }

    public decimal? Amount { get; set; }

    public string? Message { get; set; }

    public DateTime? Timestamp { get; set; }
}
