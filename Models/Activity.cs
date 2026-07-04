namespace BookingBackendWebApp.Models;

public enum ActivityType
{
    GameDrive,
    WalkingSafari,
    NightDrive,
    BirdWatching,
    Canoeing,
    Fishing,
    HorseRiding,
    CulturalTour,
    ConservationTour
}

public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ActivityType Type { get; set; }
    public int Capacity { get; set; }
    public int Duration { get; set; }
    public decimal BasePrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class Guide
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public double Rating { get; set; }
}

public class ActivitySchedule
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public int? GuideId { get; set; }
    public int? VehicleId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Capacity { get; set; }
    public int BookedCount { get; set; }
    public string Status { get; set; } = string.Empty;
}
