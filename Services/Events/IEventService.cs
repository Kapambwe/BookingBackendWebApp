namespace BookingBackendWebApp.Services.Events;

using BookingBackendWebApp.Models;

public interface IEventService
{
    Task<List<Venue>> GetVenuesAsync();
    Task<Venue?> GetVenueAsync(int id);
    Task<Venue> CreateVenueAsync(Venue venue);
    Task<Venue> UpdateVenueAsync(Venue venue);
    Task<List<Venue>> GetAvailableVenuesAsync(DateTime date, int capacity);
    Task<List<EventBooking>> GetEventBookingsAsync();
    Task<EventBooking?> GetEventBookingAsync(int id);
    Task<EventBooking> CreateEventBookingAsync(EventBooking booking);
    Task<bool> CancelEventBookingAsync(int id);
    Task<bool> ConfirmEventBookingAsync(int id);
}
