namespace BookingBackendWebApp.Services.Rangers;

using BookingBackendWebApp.Models;

public class MockRangerService : IRangerService
{
    private readonly List<Ranger> _rangers = new()
    {
        new() { Id = 1, BadgeNumber = "RN-001", Name = "Samuel Kimani", IsActive = true },
        new() { Id = 2, BadgeNumber = "RN-002", Name = "Grace Wanjiku", IsActive = true },
        new() { Id = 3, BadgeNumber = "RN-003", Name = "David Ole Tipis", IsActive = true },
        new() { Id = 4, BadgeNumber = "RN-004", Name = "Jane Akello", IsActive = false }
    };

    private readonly List<Patrol> _patrols = new()
    {
        new() { Id = 1, RangerIds = new() { 1 }, Route = "Northern Sector", StartTime = DateTime.Today.AddHours(6), EndTime = null, Status = "InProgress", Notes = "Checking reported snares" },
        new() { Id = 2, RangerIds = new() { 3 }, Route = "Eastern Boundary", StartTime = DateTime.Today.AddHours(5), EndTime = DateTime.Today.AddHours(9), Status = "Completed", Notes = "Routine patrol, no incidents" },
        new() { Id = 3, RangerIds = new() { 2 }, Route = "Tourist Trail A", StartTime = DateTime.Today.AddHours(8), EndTime = null, Status = "InProgress", Notes = "Guided walk with guests" }
    };

    private readonly List<RangerIncident> _rangerIncidents = new()
    {
        new() { Id = 1, RangerId = 1, Type = "Snares Found", Description = "3 wire snares found and removed", Location = "Northern Sector", Severity = "High", Status = "Resolved", Date = DateTime.Today.AddDays(-1) },
        new() { Id = 2, RangerId = 3, Type = "Vehicle Breakdown", Description = "Patrol vehicle broke down near Eastern Gate", Location = "Eastern Gate", Severity = "Medium", Status = "Resolved", Date = DateTime.Today.AddDays(-3) }
    };

    private int _nextRangerId = 5;
    private int _nextPatrolId = 4;
    private int _nextIncidentId = 3;

    public Task<List<Ranger>> GetRangersAsync() => Task.FromResult(_rangers.ToList());
    public Task<Ranger?> GetRangerAsync(int id) => Task.FromResult(_rangers.FirstOrDefault(r => r.Id == id));
    public Task<Ranger> CreateRangerAsync(Ranger r) { r.Id = _nextRangerId++; _rangers.Add(r); return Task.FromResult(r); }

    public Task<Ranger> UpdateRangerAsync(Ranger r)
    {
        var i = _rangers.FindIndex(x => x.Id == r.Id);
        if (i >= 0) _rangers[i] = r;
        return Task.FromResult(r);
    }

    public Task<bool> ToggleRangerStatusAsync(int id)
    {
        var r = _rangers.FirstOrDefault(x => x.Id == id);
        if (r is null) return Task.FromResult(false);
        r.IsActive = !r.IsActive;
        return Task.FromResult(true);
    }

    public Task<List<Patrol>> GetPatrolsAsync() => Task.FromResult(_patrols.ToList());

    public Task<Patrol> CreatePatrolAsync(Patrol p)
    {
        p.Id = _nextPatrolId++;
        p.Status = "InProgress";
        _patrols.Add(p);
        return Task.FromResult(p);
    }

    public Task<bool> CompletePatrolAsync(int id)
    {
        var p = _patrols.FirstOrDefault(x => x.Id == id);
        if (p is null) return Task.FromResult(false);
        p.Status = "Completed";
        p.EndTime = DateTime.Now;
        return Task.FromResult(true);
    }

    public Task<List<RangerIncident>> GetRangerIncidentsAsync() => Task.FromResult(_rangerIncidents.ToList());

    public Task<RangerIncident> ReportRangerIncidentAsync(RangerIncident i)
    {
        i.Id = _nextIncidentId++;
        i.Date = DateTime.Now;
        _rangerIncidents.Add(i);
        return Task.FromResult(i);
    }

    public Task<bool> ResolveRangerIncidentAsync(int id)
    {
        var i = _rangerIncidents.FirstOrDefault(x => x.Id == id);
        if (i is null) return Task.FromResult(false);
        i.Status = "Resolved";
        return Task.FromResult(true);
    }
}
