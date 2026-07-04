namespace BookingBackendWebApp.Services.Conservation;

using BookingBackendWebApp.Models;

public interface IConservationService
{
    Task<List<Species>> GetSpeciesAsync();
    Task<Species?> GetSpeciesAsync(int id);
    Task<Species> CreateSpeciesAsync(Species species);
    Task<Species> UpdateSpeciesAsync(Species species);
    Task<List<CensusRecord>> GetCensusRecordsAsync();
    Task<CensusRecord> CreateCensusRecordAsync(CensusRecord record);
    Task<List<AnimalTracking>> GetTrackingDataAsync();
    Task<AnimalTracking> AddTrackingDataAsync(AnimalTracking tracking);
    Task<List<Incident>> GetIncidentsAsync();
    Task<Incident> ReportIncidentAsync(Incident incident);
    Task<bool> ResolveIncidentAsync(int id);
    Task<List<ConservationProject>> GetProjectsAsync();
    Task<ConservationProject> CreateProjectAsync(ConservationProject project);
    Task<bool> UpdateProjectStatusAsync(int id, string status);
}
