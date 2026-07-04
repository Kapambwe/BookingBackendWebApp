namespace BookingBackendWebApp.Services.RevenueManagement;

using BookingBackendWebApp.Models;

public interface IRevenueManagementService
{
    Task<List<PricingRule>> GetPricingRulesAsync();
    Task<PricingRule> CreatePricingRuleAsync(PricingRule rule);
    Task<PricingRule> UpdatePricingRuleAsync(PricingRule rule);
    Task<bool> DeletePricingRuleAsync(int id);
    Task<bool> TogglePricingRuleAsync(int id);
    Task<List<Forecast>> GetForecastsAsync();
    Task<Forecast> GenerateForecastAsync(Forecast forecast);
    Task<Forecast> UpdateForecastAsync(Forecast forecast);
    Task<decimal> CalculateOptimalPriceAsync(int roomTypeId, DateTime date);
}
