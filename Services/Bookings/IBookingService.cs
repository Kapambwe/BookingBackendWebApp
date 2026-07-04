namespace BookingBackendWebApp.Services.Bookings;

using BookingBackendWebApp.Models;

public interface IBookingService
{
    Task<List<Booking>> GetBookingsAsync();
    Task<Booking?> GetBookingAsync(int id);
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<Booking> UpdateBookingAsync(Booking booking);
    Task<bool> CancelBookingAsync(int id);
    Task<bool> CheckInAsync(int id);
    Task<bool> CheckOutAsync(int id);
}
