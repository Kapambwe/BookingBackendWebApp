namespace BookingBackendWebApp.Services.ParkEntry;

using BookingBackendWebApp.Models;

public interface IParkEntryService
{
    Task<List<ParkEntryPricing>> GetPricingAsync();
    Task<ParkEntryPricing> UpdatePricingAsync(ParkEntryPricing pricing);
    Task<List<VisitorCategory>> GetVisitorCategoriesAsync();
    Task<List<PricingTier>> GetPricingTiersAsync();
    Task<List<ParkPass>> GetParkPassesAsync();
    Task<ParkPass> IssueParkPassAsync(ParkPass pass);
    Task<bool> ValidateParkPassAsync(int id);
}
