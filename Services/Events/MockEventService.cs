namespace BookingBackendWebApp.Services.Events;

using BookingBackendWebApp.Models;

public class MockEventService : IEventService
{
    private readonly List<Venue> _venues = new()
    {
        new() { Id = 1, Name = "Savannah Hall", Capacity = 200, Location = "Main conference hall with stage", HasCatering = true, HasEquipment = true, HourlyRate = 50000 },
        new() { Id = 2, Name = "River Terrace", Capacity = 80, Location = "Outdoor terrace overlooking river", HasCatering = false, HasEquipment = true, HourlyRate = 30000 },
        new() { Id = 3, Name = "Baobab Garden", Capacity = 150, Location = "Garden setting under ancient baobab", HasCatering = false, HasEquipment = true, HourlyRate = 40000 },
        new() { Id = 4, Name = "Sunset Deck", Capacity = 50, Location = "Intimate deck with sunset views", HasCatering = false, HasEquipment = false, HourlyRate = 20000 }
    };

    private readonly List<EventBooking> _eventBookings = new()
    {
        new() { Id = 1, VenueId = 1, EventName = "Wildlife Photography Workshop", Organizer = "Kenya Photo Tours", StartDate = DateTime.Today.AddDays(10), EndDate = DateTime.Today.AddDays(10), AttendeeCount = 50, Status = "Confirmed", TotalCost = 50000 },
        new() { Id = 2, VenueId = 2, EventName = "Sunset Wedding Reception", Organizer = "Jane & John", StartDate = DateTime.Today.AddDays(20), EndDate = DateTime.Today.AddDays(20), AttendeeCount = 60, Status = "Pending", TotalCost = 30000 },
        new() { Id = 3, VenueId = 4, EventName = "Corporate Dinner", Organizer = "Safari Corp", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(5), AttendeeCount = 30, Status = "Confirmed", TotalCost = 20000 }
    };

    private int _nextVenueId = 5;
    private int _nextBookingId = 4;

    public Task<List<Venue>> GetVenuesAsync() => Task.FromResult(_venues.ToList());
    public Task<Venue?> GetVenueAsync(int id) => Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));
    public Task<Venue> CreateVenueAsync(Venue v) { v.Id = _nextVenueId++; _venues.Add(v); return Task.FromResult(v); }
    public Task<Venue> UpdateVenueAsync(Venue v)
    {
        var i = _venues.FindIndex(x => x.Id == v.Id);
        if (i >= 0) _venues[i] = v;
        return Task.FromResult(v);
    }
    public Task<List<Venue>> GetAvailableVenuesAsync(DateTime date, int capacity) =>
        Task.FromResult(_venues.Where(v => v.Capacity >= capacity).ToList());
    public Task<List<EventBooking>> GetEventBookingsAsync() => Task.FromResult(_eventBookings.ToList());
    public Task<EventBooking?> GetEventBookingAsync(int id) => Task.FromResult(_eventBookings.FirstOrDefault(b => b.Id == id));
    public Task<EventBooking> CreateEventBookingAsync(EventBooking b)
    {
        b.Id = _nextBookingId++; _eventBookings.Add(b); return Task.FromResult(b);
    }
    public Task<bool> CancelEventBookingAsync(int id)
    {
        var b = _eventBookings.FirstOrDefault(b => b.Id == id);
        if (b is null) return Task.FromResult(false);
        b.Status = "Cancelled";
        return Task.FromResult(true);
    }
    public Task<bool> ConfirmEventBookingAsync(int id)
    {
        var b = _eventBookings.FirstOrDefault(b => b.Id == id);
        if (b is null) return Task.FromResult(false);
        b.Status = "Confirmed";
        return Task.FromResult(true);
    }
}
