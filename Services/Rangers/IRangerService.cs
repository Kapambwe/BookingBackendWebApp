namespace BookingBackendWebApp.Services.Rangers;

using BookingBackendWebApp.Models;

public interface IRangerService
{
    Task<List<Ranger>> GetRangersAsync();
    Task<Ranger?> GetRangerAsync(int id);
    Task<Ranger> CreateRangerAsync(Ranger ranger);
    Task<Ranger> UpdateRangerAsync(Ranger ranger);
    Task<bool> ToggleRangerStatusAsync(int id);
    Task<List<Patrol>> GetPatrolsAsync();
    Task<Patrol> CreatePatrolAsync(Patrol patrol);
    Task<bool> CompletePatrolAsync(int id);
    Task<List<RangerIncident>> GetRangerIncidentsAsync();
    Task<RangerIncident> ReportRangerIncidentAsync(RangerIncident incident);
    Task<bool> ResolveRangerIncidentAsync(int id);
}
