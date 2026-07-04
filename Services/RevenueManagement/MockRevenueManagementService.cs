namespace BookingBackendWebApp.Services.RevenueManagement;

using BookingBackendWebApp.Models;

public class MockRevenueManagementService : IRevenueManagementService
{
    private readonly List<PricingRule> _pricingRules = new()
    {
        new() { Id = 1, Name = "Peak Season Surcharge", AdjustmentType = AdjustmentType.Fixed, AdjustmentValue = 1.5m, IsActive = true },
        new() { Id = 2, Name = "Early Bird Discount", AdjustmentType = AdjustmentType.Percentage, AdjustmentValue = 0.15m, IsActive = true, Condition = "Booked 30+ days in advance" },
        new() { Id = 3, Name = "Last Minute Deal", AdjustmentType = AdjustmentType.Percentage, AdjustmentValue = 0.20m, IsActive = true, Condition = "Booked within 3 days of arrival" },
        new() { Id = 4, Name = "Loyalty Discount", AdjustmentType = AdjustmentType.Percentage, AdjustmentValue = 0.10m, IsActive = false, Condition = "Previous stay recorded" }
    };

    private readonly List<Forecast> _forecasts = new()
    {
        new() { Id = 1, Period = "July 2024", Occupancy = 0.85, Revenue = 3500000, VisitorCount = 0, Confidence = 0 },
        new() { Id = 2, Period = "August 2024", Occupancy = 0.90, Revenue = 4000000, VisitorCount = 0, Confidence = 0 },
        new() { Id = 3, Period = "June 2024", Occupancy = 0.75, Revenue = 2800000, VisitorCount = 0, Confidence = 0 }
    };

    private int _nextRuleId = 5;
    private int _nextForecastId = 4;

    public Task<List<PricingRule>> GetPricingRulesAsync() => Task.FromResult(_pricingRules.ToList());
    public Task<PricingRule> CreatePricingRuleAsync(PricingRule r) { r.Id = _nextRuleId++; _pricingRules.Add(r); return Task.FromResult(r); }
    public Task<PricingRule> UpdatePricingRuleAsync(PricingRule r)
    {
        var i = _pricingRules.FindIndex(x => x.Id == r.Id);
        if (i >= 0) _pricingRules[i] = r;
        return Task.FromResult(r);
    }
    public Task<bool> DeletePricingRuleAsync(int id)
    {
        var r = _pricingRules.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(_pricingRules.Remove(r!));
    }
    public Task<bool> TogglePricingRuleAsync(int id)
    {
        var r = _pricingRules.FirstOrDefault(x => x.Id == id);
        if (r is null) return Task.FromResult(false);
        r.IsActive = !r.IsActive;
        return Task.FromResult(true);
    }
    public Task<List<Forecast>> GetForecastsAsync() => Task.FromResult(_forecasts.ToList());
    public Task<Forecast> GenerateForecastAsync(Forecast f) { f.Id = _nextForecastId++; _forecasts.Add(f); return Task.FromResult(f); }
    public Task<Forecast> UpdateForecastAsync(Forecast f)
    {
        var i = _forecasts.FindIndex(x => x.Id == f.Id);
        if (i >= 0) _forecasts[i] = f;
        return Task.FromResult(f);
    }
    public Task<decimal> CalculateOptimalPriceAsync(int roomTypeId, DateTime date)
    {
        var isPeak = date.Month >= 7 && date.Month <= 9;
        var basePrice = 8000m;
        var optimal = isPeak ? basePrice * 1.5m : basePrice;
        return Task.FromResult(optimal);
    }
}
