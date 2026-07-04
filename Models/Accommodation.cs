namespace BookingBackendWebApp.Models;

public enum RoomType
{
    Standard,
    Deluxe,
    Executive,
    Presidential
}

public enum LodgeType
{
    Chalet,
    Tent,
    Villa,
    Cabin
}

public enum RoomStatus
{
    Available,
    Occupied,
    Maintenance,
    Cleaning,
    OutOfOrder
}

public enum HousekeepingStatus
{
    Pending,
    InProgress,
    Completed
}

public enum MaintenancePriority
{
    Low,
    Medium,
    High,
    Critical
}

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
    public LodgeType LodgeType { get; set; }
    public int Capacity { get; set; }
    public decimal BaseRate { get; set; }
    public RoomStatus Status { get; set; }
    public int Floor { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class HousekeepingTask
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string AssignedTo { get; set; } = string.Empty;
    public HousekeepingStatus Status { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class MaintenanceRecord
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string Description { get; set; } = string.Empty;
    public MaintenancePriority Priority { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
