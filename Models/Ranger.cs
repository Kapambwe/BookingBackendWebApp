namespace BookingBackendWebApp.Models;

public class Ranger
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public string BadgeNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public double CurrentLatitude { get; set; }
    public double CurrentLongitude { get; set; }
}

public class Patrol
{
    public int Id { get; set; }
    public List<int> RangerIds { get; set; } = new();
    public string Route { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

public class RangerIncident
{
    public int Id { get; set; }
    public int RangerId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double GpsLatitude { get; set; }
    public double GpsLongitude { get; set; }
    public string Severity { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty;
}
