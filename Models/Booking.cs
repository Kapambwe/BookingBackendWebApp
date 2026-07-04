namespace BookingBackendWebApp.Models;

public enum BookingType
{
    Room,
    Chalet,
    Tent,
    Campsite,
    GameDrive,
    BoatCruise,
    FishingPermit,
    HikingPermit,
    ParkEntry,
    PhotographyPermit,
    BirdWatching,
    SafariPackage
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    CheckedIn,
    CheckedOut,
    Cancelled,
    NoShow
}

public class Booking
{
    public int Id { get; set; }
    public string BookingNumber { get; set; } = string.Empty;
    public BookingType BookingType { get; set; }
    public BookingStatus Status { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public string GuestEmail { get; set; } = string.Empty;
    public string GuestPhone { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal BalanceAmount { get; set; }
    public int? PackageId { get; set; }
    public int? RoomId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Notes { get; set; } = string.Empty;
    public List<BookingLineItem> LineItems { get; set; } = new();
}

public class BookingLineItem
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}
