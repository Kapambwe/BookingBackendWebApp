namespace BookingBackendWebApp.Services.GovernmentIntelligence;

using BookingBackendWebApp.Models;

public interface IGovernmentIntelligenceService
{
    Task<List<GovernmentKpi>> GetKpisAsync();
    Task<GovernmentKpi> CreateKpiAsync(GovernmentKpi kpi);
    Task<GovernmentKpi> UpdateKpiAsync(GovernmentKpi kpi);
    Task<bool> DeleteKpiAsync(int id);
    Task<List<Scorecard>> GetScorecardsAsync();
    Task<Scorecard> CreateScorecardAsync(Scorecard scorecard);
    Task<Scorecard> UpdateScorecardAsync(Scorecard scorecard);
    Task<Scorecard> GenerateQuarterlyReportAsync(int year, int quarter);
}
