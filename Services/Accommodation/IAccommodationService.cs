namespace BookingBackendWebApp.Services.Accommodation;

using BookingBackendWebApp.Models;

public interface IAccommodationService
{
    Task<List<Room>> GetRoomsAsync();
    Task<Room?> GetRoomAsync(int id);
    Task<List<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
    Task<Room> CreateRoomAsync(Room room);
    Task<Room> UpdateRoomAsync(Room room);
    Task<List<HousekeepingTask>> GetHousekeepingTasksAsync();
    Task<HousekeepingTask> CreateHousekeepingTaskAsync(HousekeepingTask task);
    Task<bool> CompleteHousekeepingTaskAsync(int id);
    Task<List<MaintenanceRecord>> GetMaintenanceRecordsAsync();
    Task<MaintenanceRecord> CreateMaintenanceRecordAsync(MaintenanceRecord record);
    Task<bool> ResolveMaintenanceRecordAsync(int id);
}
