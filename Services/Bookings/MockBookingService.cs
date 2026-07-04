namespace BookingBackendWebApp.Services.Bookings;

using BookingBackendWebApp.Models;

public class MockBookingService : IBookingService
{
    private readonly List<Booking> _bookings = new()
    {
        new()
        {
            Id = 1, BookingNumber = "BK-2024-001", BookingType = BookingType.Room,
            Status = BookingStatus.Confirmed, GuestName = "John Doe",
            GuestEmail = "john.doe@email.com", GuestPhone = "+254700111001",
            Nationality = "Kenyan", PassportNumber = "KN123456",
            CheckInDate = new DateTime(2024, 6, 15), CheckOutDate = new DateTime(2024, 6, 18),
            Adults = 2, Children = 1, TotalAmount = 45000, PaidAmount = 22500,
            BalanceAmount = 22500, PackageId = 1, RoomId = 101,
            CreatedAt = new DateTime(2024, 5, 1), Notes = "Prefers ground floor",
            LineItems = new()
            {
                new() { Id = 101, BookingId = 1, Description = "Standard Room Accommodation (3 Nights)", Quantity = 3, UnitPrice = 15000, TotalPrice = 45000, Date = new DateTime(2024, 6, 15) }
            }
        },
        new()
        {
            Id = 2, BookingNumber = "BK-2024-002", BookingType = BookingType.Chalet,
            Status = BookingStatus.CheckedIn, GuestName = "Jane Smith",
            GuestEmail = "jane.smith@email.com", GuestPhone = "+254700111002",
            Nationality = "British", PassportNumber = "GB789012",
            CheckInDate = new DateTime(2024, 6, 10), CheckOutDate = new DateTime(2024, 6, 20),
            Adults = 2, Children = 0, TotalAmount = 120000, PaidAmount = 120000,
            BalanceAmount = 0, PackageId = 3, RoomId = 201,
            CreatedAt = new DateTime(2024, 4, 15), Notes = "Honeymoon",
            LineItems = new()
            {
                new() { Id = 201, BookingId = 2, Description = "Luxury Chalet Stay (10 Nights)", Quantity = 10, UnitPrice = 10000, TotalPrice = 100000, Date = new DateTime(2024, 6, 10) },
                new() { Id = 202, BookingId = 2, Description = "Guided Game Drives", Quantity = 2, UnitPrice = 10000, TotalPrice = 20000, Date = new DateTime(2024, 6, 12) }
            }
        },
        new()
        {
            Id = 3, BookingNumber = "BK-2024-003", BookingType = BookingType.GameDrive,
            Status = BookingStatus.Pending, GuestName = "Ahmed Hassan",
            GuestEmail = "ahmed@email.com", GuestPhone = "+254700111003",
            Nationality = "Tanzanian", PassportNumber = "TZ345678",
            CheckInDate = new DateTime(2024, 7, 1), CheckOutDate = new DateTime(2024, 7, 2),
            Adults = 4, Children = 2, TotalAmount = 28000, PaidAmount = 5000,
            BalanceAmount = 23000, CreatedAt = new DateTime(2024, 6, 1),
            LineItems = new()
            {
                new() { Id = 301, BookingId = 3, Description = "Adult Day Game Drive Safari", Quantity = 4, UnitPrice = 5000, TotalPrice = 20000, Date = new DateTime(2024, 7, 1) },
                new() { Id = 302, BookingId = 3, Description = "Child Day Game Drive Safari", Quantity = 2, UnitPrice = 4000, TotalPrice = 8000, Date = new DateTime(2024, 7, 1) }
            }
        },
        new()
        {
            Id = 4, BookingNumber = "BK-2024-004", BookingType = BookingType.ParkEntry,
            Status = BookingStatus.Confirmed, GuestName = "Maria Gonzalez",
            GuestEmail = "maria@email.com", GuestPhone = "+254700111004",
            Nationality = "Spanish", PassportNumber = "ES901234",
            CheckInDate = new DateTime(2024, 6, 20), CheckOutDate = new DateTime(2024, 6, 20),
            Adults = 2, Children = 0, TotalAmount = 2000, PaidAmount = 2000,
            BalanceAmount = 0, CreatedAt = new DateTime(2024, 6, 10),
            LineItems = new()
            {
                new() { Id = 401, BookingId = 4, Description = "National Park Entry Pass (Adult)", Quantity = 2, UnitPrice = 1000, TotalPrice = 2000, Date = new DateTime(2024, 6, 20) }
            }
        },
        new()
        {
            Id = 5, BookingNumber = "BK-2024-005", BookingType = BookingType.SafariPackage,
            Status = BookingStatus.CheckedOut, GuestName = "Peter Kimani",
            GuestEmail = "peter@email.com", GuestPhone = "+254700111005",
            Nationality = "Kenyan", PassportNumber = "KN567890",
            CheckInDate = new DateTime(2024, 5, 20), CheckOutDate = new DateTime(2024, 5, 27),
            Adults = 2, Children = 3, TotalAmount = 210000, PaidAmount = 210000,
            BalanceAmount = 0, PackageId = 4, RoomId = 301,
            CreatedAt = new DateTime(2024, 4, 1), Notes = "Family vacation",
            LineItems = new()
            {
                new() { Id = 501, BookingId = 5, Description = "Gold Safari Family Package (7 Nights)", Quantity = 7, UnitPrice = 30000, TotalPrice = 210000, Date = new DateTime(2024, 5, 20) }
            }
        },
        new()
        {
            Id = 6, BookingNumber = "BK-2024-006", BookingType = BookingType.Room,
            Status = BookingStatus.Cancelled, GuestName = "Lucy Wanjiku",
            GuestEmail = "lucy@email.com", GuestPhone = "+254700111006",
            Nationality = "Kenyan", CheckInDate = new DateTime(2024, 6, 5),
            CheckOutDate = new DateTime(2024, 6, 8), Adults = 1, Children = 0,
            TotalAmount = 18000, PaidAmount = 0, BalanceAmount = 0,
            RoomId = 102, CreatedAt = new DateTime(2024, 5, 15),
            Notes = "Cancelled due to illness",
            LineItems = new()
            {
                new() { Id = 601, BookingId = 6, Description = "Budget Room Stay (3 Nights)", Quantity = 3, UnitPrice = 6000, TotalPrice = 18000, Date = new DateTime(2024, 6, 5) }
            }
        },
        new()
        {
            Id = 7, BookingNumber = "BK-2024-007", BookingType = BookingType.Campsite,
            Status = BookingStatus.Confirmed, GuestName = "David Ochieng",
            GuestEmail = "david@email.com", GuestPhone = "+254700111007",
            Nationality = "Ugandan", PassportNumber = "UG112233",
            CheckInDate = new DateTime(2024, 7, 10), CheckOutDate = new DateTime(2024, 7, 15),
            Adults = 3, Children = 0, TotalAmount = 7500, PaidAmount = 3750,
            BalanceAmount = 3750, CreatedAt = new DateTime(2024, 6, 20),
            LineItems = new()
            {
                new() { Id = 701, BookingId = 7, Description = "Wilderness Campsite Rental (5 Nights)", Quantity = 5, UnitPrice = 1500, TotalPrice = 7500, Date = new DateTime(2024, 7, 10) }
            }
        },
        new()
        {
            Id = 8, BookingNumber = "BK-2024-008", BookingType = BookingType.BoatCruise,
            Status = BookingStatus.Confirmed, GuestName = "Sarah Johnson",
            GuestEmail = "sarah@email.com", GuestPhone = "+254700111008",
            Nationality = "American", PassportNumber = "US445566",
            CheckInDate = new DateTime(2024, 6, 25), CheckOutDate = new DateTime(2024, 6, 25),
            Adults = 6, Children = 0, TotalAmount = 12000, PaidAmount = 12000,
            BalanceAmount = 0, CreatedAt = new DateTime(2024, 6, 5),
            LineItems = new()
            {
                new() { Id = 801, BookingId = 8, Description = "Sunset Boat Cruise Ticket", Quantity = 6, UnitPrice = 2000, TotalPrice = 12000, Date = new DateTime(2024, 6, 25) }
            }
        }
    };

    private int _nextId = 9;

    public Task<List<Booking>> GetBookingsAsync() =>
        Task.FromResult(_bookings.ToList());

    public Task<Booking?> GetBookingAsync(int id) =>
        Task.FromResult(_bookings.FirstOrDefault(b => b.Id == id));

    public Task<Booking> CreateBookingAsync(Booking booking)
    {
        booking.Id = _nextId++;
        booking.BookingNumber = $"BK-2024-{_nextId - 1:D3}";
        booking.CreatedAt = DateTime.Now;
        booking.UpdatedAt = DateTime.Now;
        booking.BalanceAmount = booking.TotalAmount - booking.PaidAmount;
        _bookings.Add(booking);
        return Task.FromResult(booking);
    }

    public Task<Booking> UpdateBookingAsync(Booking booking)
    {
        var existing = _bookings.FirstOrDefault(b => b.Id == booking.Id);
        if (existing is null) return Task.FromResult(booking);
        var index = _bookings.IndexOf(existing);
        booking.UpdatedAt = DateTime.Now;
        booking.BalanceAmount = booking.TotalAmount - booking.PaidAmount;
        _bookings[index] = booking;
        return Task.FromResult(booking);
    }

    public Task<bool> CancelBookingAsync(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking is null) return Task.FromResult(false);
        booking.Status = BookingStatus.Cancelled;
        booking.UpdatedAt = DateTime.Now;
        return Task.FromResult(true);
    }

    public Task<bool> CheckInAsync(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking is null) return Task.FromResult(false);
        booking.Status = BookingStatus.CheckedIn;
        booking.UpdatedAt = DateTime.Now;
        return Task.FromResult(true);
    }

    public Task<bool> CheckOutAsync(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking is null) return Task.FromResult(false);
        booking.Status = BookingStatus.CheckedOut;
        booking.UpdatedAt = DateTime.Now;
        return Task.FromResult(true);
    }
}
