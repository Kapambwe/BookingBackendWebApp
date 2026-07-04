namespace BookingBackendWebApp.Services.Accommodation;

using BookingBackendWebApp.Models;

public class MockAccommodationService : IAccommodationService
{
    private readonly List<Room> _rooms = new()
    {
        new() { Id = 101, RoomNumber = "101", RoomType = RoomType.Standard, LodgeType = LodgeType.Villa, Status = RoomStatus.Available, Capacity = 2, BaseRate = 8000, Description = "Standard room with garden view" },
        new() { Id = 102, RoomNumber = "102", RoomType = RoomType.Standard, LodgeType = LodgeType.Villa, Status = RoomStatus.Occupied, Capacity = 2, BaseRate = 8000, Description = "Standard room with garden view" },
        new() { Id = 103, RoomNumber = "103", RoomType = RoomType.Standard, LodgeType = LodgeType.Villa, Status = RoomStatus.Available, Capacity = 2, BaseRate = 8000, Description = "Standard room near pool" },
        new() { Id = 201, RoomNumber = "201", RoomType = RoomType.Deluxe, LodgeType = LodgeType.Villa, Status = RoomStatus.Available, Capacity = 3, BaseRate = 15000, Description = "Deluxe room with savannah view" },
        new() { Id = 202, RoomNumber = "202", RoomType = RoomType.Deluxe, LodgeType = LodgeType.Villa, Status = RoomStatus.Maintenance, Capacity = 3, BaseRate = 15000, Description = "Deluxe room - under maintenance" },
        new() { Id = 301, RoomNumber = "301", RoomType = RoomType.Executive, LodgeType = LodgeType.Villa, Status = RoomStatus.Available, Capacity = 4, BaseRate = 25000, Description = "Family suite with panoramic view" },
        new() { Id = 302, RoomNumber = "302", RoomType = RoomType.Executive, LodgeType = LodgeType.Villa, Status = RoomStatus.Available, Capacity = 4, BaseRate = 25000, Description = "Honeymoon suite" },
        new() { Id = 401, RoomNumber = "CH-01", RoomType = RoomType.Presidential, LodgeType = LodgeType.Chalet, Status = RoomStatus.Available, Capacity = 6, BaseRate = 40000, Description = "Premium chalet with private pool" },
        new() { Id = 402, RoomNumber = "CH-02", RoomType = RoomType.Presidential, LodgeType = LodgeType.Chalet, Status = RoomStatus.Available, Capacity = 6, BaseRate = 40000, Description = "Premium chalet with outdoor shower" },
        new() { Id = 501, RoomNumber = "TN-01", RoomType = RoomType.Standard, LodgeType = LodgeType.Tent, Status = RoomStatus.Available, Capacity = 2, BaseRate = 12000, Description = "Luxury glamping tent" },
        new() { Id = 502, RoomNumber = "TN-02", RoomType = RoomType.Standard, LodgeType = LodgeType.Tent, Status = RoomStatus.Available, Capacity = 2, BaseRate = 12000, Description = "Luxury glamping tent with river view" }
    };

    private readonly List<HousekeepingTask> _housekeepingTasks = new()
    {
        new() { Id = 1, RoomId = 101, AssignedTo = "Mary Wanjiku", Status = HousekeepingStatus.Pending, ScheduledDate = DateTime.Today, Notes = "Daily cleaning" },
        new() { Id = 2, RoomId = 102, AssignedTo = "John Kamau", Status = HousekeepingStatus.InProgress, ScheduledDate = DateTime.Today, Notes = "Deep cleaning - checkout" }
    };

    private readonly List<MaintenanceRecord> _maintenanceRecords = new()
    {
        new() { Id = 1, RoomId = 202, Description = "AC not cooling", Status = "InProgress", CreatedAt = DateTime.Today.AddDays(-1), Priority = MaintenancePriority.High },
        new() { Id = 2, RoomId = 101, Description = "Leaking faucet", Status = "Pending", CreatedAt = DateTime.Today, Priority = MaintenancePriority.Low }
    };

    private int _nextHousekeepingId = 3;
    private int _nextMaintenanceId = 3;

    public Task<List<Room>> GetRoomsAsync() => Task.FromResult(_rooms.ToList());
    public Task<Room?> GetRoomAsync(int id) => Task.FromResult(_rooms.FirstOrDefault(r => r.Id == id));

    public Task<List<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut) =>
        Task.FromResult(_rooms.Where(r => r.Status == RoomStatus.Available).ToList());

    public Task<Room> CreateRoomAsync(Room room) { _rooms.Add(room); return Task.FromResult(room); }
    public Task<Room> UpdateRoomAsync(Room room)
    {
        var i = _rooms.FindIndex(r => r.Id == room.Id);
        if (i >= 0) _rooms[i] = room;
        return Task.FromResult(room);
    }

    public Task<List<HousekeepingTask>> GetHousekeepingTasksAsync() =>
        Task.FromResult(_housekeepingTasks.ToList());

    public Task<HousekeepingTask> CreateHousekeepingTaskAsync(HousekeepingTask task)
    {
        task.Id = _nextHousekeepingId++;
        _housekeepingTasks.Add(task);
        return Task.FromResult(task);
    }

    public Task<bool> CompleteHousekeepingTaskAsync(int id)
    {
        var t = _housekeepingTasks.FirstOrDefault(t => t.Id == id);
        if (t is null) return Task.FromResult(false);
        t.Status = HousekeepingStatus.Completed;
        return Task.FromResult(true);
    }

    public Task<List<MaintenanceRecord>> GetMaintenanceRecordsAsync() =>
        Task.FromResult(_maintenanceRecords.ToList());

    public Task<MaintenanceRecord> CreateMaintenanceRecordAsync(MaintenanceRecord record)
    {
        record.Id = _nextMaintenanceId++;
        _maintenanceRecords.Add(record);
        return Task.FromResult(record);
    }

    public Task<bool> ResolveMaintenanceRecordAsync(int id)
    {
        var r = _maintenanceRecords.FirstOrDefault(r => r.Id == id);
        if (r is null) return Task.FromResult(false);
        r.Status = "Resolved";
        return Task.FromResult(true);
    }
}
