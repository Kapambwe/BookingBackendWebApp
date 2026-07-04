namespace BookingBackendWebApp.Services.Pos;

using BookingBackendWebApp.Models;

public interface IPosService
{
    Task<List<PosMenuItem>> GetMenuItemsAsync();
    Task<PosMenuItem> CreateMenuItemAsync(PosMenuItem item);
    Task<PosMenuItem> UpdateMenuItemAsync(PosMenuItem item);
    Task<bool> ToggleMenuItemAvailabilityAsync(int id);
    Task<List<PosOrder>> GetOrdersAsync();
    Task<PosOrder?> GetOrderAsync(int id);
    Task<PosOrder> CreateOrderAsync(PosOrder order);
    Task<PosOrder> AddOrderItemAsync(int orderId, PosOrderItem item);
    Task<bool> ProcessPaymentAsync(int orderId, decimal amount);
    Task<PosEndOfDay> GetEndOfDayAsync(DateTime date);
    Task<PosEndOfDay> CloseDayAsync(PosEndOfDay eod);
}
