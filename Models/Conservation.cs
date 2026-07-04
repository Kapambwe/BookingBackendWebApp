namespace BookingBackendWebApp.Models;

public enum PopulationTrend
{
    Increasing,
    Stable,
    Declining
}

public enum IncidentType
{
    Poaching,
    IllegalFishing,
    IllegalLogging,
    HumanWildlifeConflict
}

public enum IncidentSeverity
{
    Low,
    Medium,
    High,
    Critical
}

public enum IncidentStatus
{
    Open,
    Investigating,
    Resolved
}

public class Species
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public int Population { get; set; }
    public PopulationTrend PopulationTrend { get; set; }
    public string ConservationStatus { get; set; } = string.Empty;
    public DateTime? LastCensusDate { get; set; }
}

public class CensusRecord
{
    public int Id { get; set; }
    public int SpeciesId { get; set; }
    public int Count { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
}

public class AnimalTracking
{
    public int Id { get; set; }
    public int SpeciesId { get; set; }
    public string AnimalName { get; set; } = string.Empty;
    public double GpsLatitude { get; set; }
    public double GpsLongitude { get; set; }
    public DateTime LastSeen { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class Incident
{
    public int Id { get; set; }
    public IncidentType Type { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public IncidentSeverity Severity { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ReportedBy { get; set; } = string.Empty;
    public IncidentStatus Status { get; set; }
    public double GpsLatitude { get; set; }
    public double GpsLongitude { get; set; }
}

public class ConservationProject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Budget { get; set; }
    public decimal Spent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
