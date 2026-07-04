namespace BookingBackendWebApp.Services.Conservation;

using BookingBackendWebApp.Models;

public class MockConservationService : IConservationService
{
    private readonly List<Species> _species = new()
    {
        new() { Id = 1, Name = "African Elephant", ScientificName = "Loxodonta africana", ConservationStatus = "Endangered", Population = 1200 },
        new() { Id = 2, Name = "Lion", ScientificName = "Panthera leo", ConservationStatus = "Vulnerable", Population = 450 },
        new() { Id = 3, Name = "Black Rhino", ScientificName = "Diceros bicornis", ConservationStatus = "Critically Endangered", Population = 35 },
        new() { Id = 4, Name = "Giraffe", ScientificName = "Giraffa camelopardalis", ConservationStatus = "Vulnerable", Population = 800 },
        new() { Id = 5, Name = "African Wild Dog", ScientificName = "Lycaon pictus", ConservationStatus = "Endangered", Population = 60 }
    };

    private readonly List<CensusRecord> _censusRecords = new()
    {
        new() { Id = 1, SpeciesId = 1, Count = 25, Location = "Northern Sector", Date = DateTime.Today.AddDays(-10), Method = "Aerial Survey" },
        new() { Id = 2, SpeciesId = 2, Count = 8, Location = "Central Plains", Date = DateTime.Today.AddDays(-7), Method = "Ground Observation" },
        new() { Id = 3, SpeciesId = 4, Count = 15, Location = "Eastern Woodlands", Date = DateTime.Today.AddDays(-5), Method = "Aerial Survey" }
    };

    private readonly List<AnimalTracking> _trackingData = new()
    {
        new() { Id = 1, SpeciesId = 1, AnimalName = "Elephant-001", GpsLatitude = -1.234, GpsLongitude = 36.789, LastSeen = DateTime.Today.AddHours(-6), Status = "Active" },
        new() { Id = 2, SpeciesId = 2, AnimalName = "Lion-001", GpsLatitude = -1.456, GpsLongitude = 36.567, LastSeen = DateTime.Today.AddHours(-2), Status = "Active" }
    };

    private readonly List<Incident> _incidents = new()
    {
        new() { Id = 1, Type = IncidentType.Poaching, Description = "Snares found in Northern Sector", Location = "Northern Sector", Severity = IncidentSeverity.High, Status = IncidentStatus.Investigating, Date = DateTime.Today.AddDays(-3), ReportedBy = "Ranger Kamau" },
        new() { Id = 2, Type = IncidentType.HumanWildlifeConflict, Description = "Elephant crop raiding reported", Location = "Eastern Boundary", Severity = IncidentSeverity.Medium, Status = IncidentStatus.Resolved, Date = DateTime.Today.AddDays(-5), ReportedBy = "Community Liaison" }
    };

    private readonly List<ConservationProject> _projects = new()
    {
        new() { Id = 1, Name = "Rhino Sanctuary Expansion", Description = "Expanding protected area for black rhinos", Budget = 5000000, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2025, 2, 28), Status = "In Progress" },
        new() { Id = 2, Name = "Community Water Holes", Description = "Building water holes to reduce human-wildlife conflict", Budget = 1500000, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31), Status = "In Progress" },
        new() { Id = 3, Name = "Anti-Poaching Unit", Description = "Training and equipping anti-poaching rangers", Budget = 3000000, StartDate = new DateTime(2024, 6, 1), Status = "Planning" }
    };

    private int _nextSpeciesId = 6;
    private int _nextCensusId = 4;
    private int _nextTrackingId = 3;
    private int _nextIncidentId = 3;
    private int _nextProjectId = 4;

    public Task<List<Species>> GetSpeciesAsync() => Task.FromResult(_species.ToList());
    public Task<Species?> GetSpeciesAsync(int id) => Task.FromResult(_species.FirstOrDefault(s => s.Id == id));
    public Task<Species> CreateSpeciesAsync(Species s) { s.Id = _nextSpeciesId++; _species.Add(s); return Task.FromResult(s); }
    public Task<Species> UpdateSpeciesAsync(Species s)
    {
        var i = _species.FindIndex(x => x.Id == s.Id);
        if (i >= 0) _species[i] = s;
        return Task.FromResult(s);
    }
    public Task<List<CensusRecord>> GetCensusRecordsAsync() => Task.FromResult(_censusRecords.ToList());
    public Task<CensusRecord> CreateCensusRecordAsync(CensusRecord r) { r.Id = _nextCensusId++; _censusRecords.Add(r); return Task.FromResult(r); }
    public Task<List<AnimalTracking>> GetTrackingDataAsync() => Task.FromResult(_trackingData.ToList());
    public Task<AnimalTracking> AddTrackingDataAsync(AnimalTracking t) { t.Id = _nextTrackingId++; _trackingData.Add(t); return Task.FromResult(t); }
    public Task<List<Incident>> GetIncidentsAsync() => Task.FromResult(_incidents.ToList());
    public Task<Incident> ReportIncidentAsync(Incident i) { i.Id = _nextIncidentId++; _incidents.Add(i); return Task.FromResult(i); }
    public Task<bool> ResolveIncidentAsync(int id)
    {
        var i = _incidents.FirstOrDefault(x => x.Id == id);
        if (i is null) return Task.FromResult(false);
        i.Status = IncidentStatus.Resolved;
        return Task.FromResult(true);
    }
    public Task<List<ConservationProject>> GetProjectsAsync() => Task.FromResult(_projects.ToList());
    public Task<ConservationProject> CreateProjectAsync(ConservationProject p) { p.Id = _nextProjectId++; _projects.Add(p); return Task.FromResult(p); }
    public Task<bool> UpdateProjectStatusAsync(int id, string status)
    {
        var p = _projects.FirstOrDefault(x => x.Id == id);
        if (p is null) return Task.FromResult(false);
        p.Status = status;
        return Task.FromResult(true);
    }
}
