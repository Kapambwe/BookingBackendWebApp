namespace BookingBackendWebApp.Services.ParkEntry;

using BookingBackendWebApp.Models;

public class MockParkEntryService : IParkEntryService
{
    private readonly List<ParkEntryPricing> _pricing = new()
    {
        new() { Id = 1, VisitorCategory = VisitorCategory.Adult, PricingTier = PricingTier.Citizen, DailyRate = 500 },
        new() { Id = 2, VisitorCategory = VisitorCategory.Child, PricingTier = PricingTier.Citizen, DailyRate = 200 },
        new() { Id = 3, VisitorCategory = VisitorCategory.Adult, PricingTier = PricingTier.Resident, DailyRate = 1000 },
        new() { Id = 4, VisitorCategory = VisitorCategory.Child, PricingTier = PricingTier.Resident, DailyRate = 500 },
        new() { Id = 5, VisitorCategory = VisitorCategory.Adult, PricingTier = PricingTier.International, DailyRate = 50 },
        new() { Id = 6, VisitorCategory = VisitorCategory.Child, PricingTier = PricingTier.International, DailyRate = 25 }
    };

    private readonly List<VisitorCategory> _visitorCategories = new()
    {
        VisitorCategory.Adult,
        VisitorCategory.Child,
        VisitorCategory.Student,
        VisitorCategory.Senior
    };

    private readonly List<PricingTier> _pricingTiers = new()
    {
        PricingTier.Citizen,
        PricingTier.Resident,
        PricingTier.International
    };

    private readonly List<ParkPass> _parkPasses = new()
    {
        new() { Id = 1, PassNumber = "PP-2024-001", VisitorName = "John Doe", PassType = PassType.Daily, PricingTierId = 1, IssueDate = DateTime.Today, ExpiryDate = DateTime.Today.AddDays(1), Fee = 500 },
        new() { Id = 2, PassNumber = "PP-2024-002", VisitorName = "Jane Smith", PassType = PassType.Daily, PricingTierId = 3, IssueDate = DateTime.Today.AddDays(-1), ExpiryDate = DateTime.Today.AddDays(2), Fee = 50 }
    };

    private int _nextPassId = 3;

    public Task<List<ParkEntryPricing>> GetPricingAsync() => Task.FromResult(_pricing.ToList());

    public Task<ParkEntryPricing> UpdatePricingAsync(ParkEntryPricing pricing)
    {
        var i = _pricing.FindIndex(p => p.Id == pricing.Id);
        if (i >= 0) _pricing[i] = pricing;
        return Task.FromResult(pricing);
    }

    public Task<List<VisitorCategory>> GetVisitorCategoriesAsync() =>
        Task.FromResult(_visitorCategories.ToList());

    public Task<List<PricingTier>> GetPricingTiersAsync() =>
        Task.FromResult(_pricingTiers.ToList());

    public Task<List<ParkPass>> GetParkPassesAsync() =>
        Task.FromResult(_parkPasses.ToList());

    public Task<ParkPass> IssueParkPassAsync(ParkPass pass)
    {
        pass.Id = _nextPassId++;
        pass.PassNumber = $"PP-2024-{_nextPassId - 1:D3}";
        pass.IssueDate = DateTime.Now;
        _parkPasses.Add(pass);
        return Task.FromResult(pass);
    }

    public Task<bool> ValidateParkPassAsync(int id)
    {
        var pass = _parkPasses.FirstOrDefault(p => p.Id == id);
        if (pass is null) return Task.FromResult(false);
        return Task.FromResult(pass.ExpiryDate >= DateTime.Today);
    }
}
