namespace BookingBackendWebApp.Services.GovernmentIntelligence;

using BookingBackendWebApp.Models;

public class MockGovernmentIntelligenceService : IGovernmentIntelligenceService
{
    private readonly List<GovernmentKpi> _kpis = new()
    {
        new() { Id = 1, Category = "Tourism", Metric = "Tourist Arrivals (Annual)", Value = 1850000, Period = "2024", PreviousValue = 1700000, Change = 8.8 },
        new() { Id = 2, Category = "Finance", Metric = "Revenue Collection", Value = 475000000, Period = "2024", PreviousValue = 450000000, Change = 5.6 },
        new() { Id = 3, Category = "Operations", Metric = "Park Visitors (Monthly)", Value = 52300, Period = "June 2024", PreviousValue = 48900, Change = 7.0 },
        new() { Id = 4, Category = "Security", Metric = "Poaching Incidents", Value = 2, Period = "2024", PreviousValue = 5, Change = -60.0 },
        new() { Id = 5, Category = "Social", Metric = "Community Engagement Events", Value = 18, Period = "2024", PreviousValue = 15, Change = 20.0 }
    };

    private readonly List<Scorecard> _scorecards = new()
    {
        new() { Id = 1, EntityName = "Conservation Authority - Q1 2024", BusinessHealthScore = 82.5, TourismCreditScore = 78.0, SustainabilityScore = 85.0, FinancingReadinessScore = 80.0, Period = "2024 Q1" },
        new() { Id = 2, EntityName = "Conservation Authority - Q2 2024", BusinessHealthScore = 78.0, TourismCreditScore = 72.0, SustainabilityScore = 80.0, FinancingReadinessScore = 76.0, Period = "2024 Q2" }
    };

    private int _nextKpiId = 6;
    private int _nextScorecardId = 3;

    public Task<List<GovernmentKpi>> GetKpisAsync() => Task.FromResult(_kpis.ToList());
    public Task<GovernmentKpi> CreateKpiAsync(GovernmentKpi k) { k.Id = _nextKpiId++; _kpis.Add(k); return Task.FromResult(k); }

    public Task<GovernmentKpi> UpdateKpiAsync(GovernmentKpi k)
    {
        var i = _kpis.FindIndex(x => x.Id == k.Id);
        if (i >= 0) _kpis[i] = k;
        return Task.FromResult(k);
    }

    public Task<bool> DeleteKpiAsync(int id)
    {
        var k = _kpis.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(_kpis.Remove(k!));
    }

    public Task<List<Scorecard>> GetScorecardsAsync() => Task.FromResult(_scorecards.ToList());

    public Task<Scorecard> CreateScorecardAsync(Scorecard s)
    {
        s.Id = _nextScorecardId++;
        _scorecards.Add(s);
        return Task.FromResult(s);
    }

    public Task<Scorecard> UpdateScorecardAsync(Scorecard s)
    {
        var i = _scorecards.FindIndex(x => x.Id == s.Id);
        if (i >= 0) _scorecards[i] = s;
        return Task.FromResult(s);
    }

    public Task<Scorecard> GenerateQuarterlyReportAsync(int year, int quarter)
    {
        var scorecard = new Scorecard
        {
            Id = _nextScorecardId++,
            EntityName = $"Conservation Authority - Q{quarter} {year}",
            BusinessHealthScore = 80.0,
            TourismCreditScore = 75.0,
            SustainabilityScore = 82.0,
            FinancingReadinessScore = 78.0,
            Period = $"{year} Q{quarter}"
        };
        _scorecards.Add(scorecard);
        return Task.FromResult(scorecard);
    }
}
