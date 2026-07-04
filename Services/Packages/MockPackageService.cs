namespace BookingBackendWebApp.Services.Packages;

using BookingBackendWebApp.Models;

public class MockPackageService : IPackageService
{
    private readonly List<Package> _packages = new()
    {
        new()
        {
            Id = 1, Name = "Bronze Explorer", Description = "Essential safari experience with basic accommodation and meals.",
            Tier = PackageTier.Bronze, BasePrice = 15000, PeakMultiplier = 1.2m,
            IncludesAccommodation = true, IncludesMeals = true, IncludesTransfers = false,
            IncludesGameDrives = false, IncludesParkEntry = true, IncludesGuide = false,
            IsActive = true, CreatedAt = new DateTime(2024, 1, 1)
        },
        new()
        {
            Id = 2, Name = "Silver Adventurer", Description = "Enhanced package with game drives and transfers included.",
            Tier = PackageTier.Silver, BasePrice = 35000, PeakMultiplier = 1.3m,
            IncludesAccommodation = true, IncludesMeals = true, IncludesTransfers = true,
            IncludesGameDrives = true, IncludesParkEntry = true, IncludesGuide = false,
            IsActive = true, CreatedAt = new DateTime(2024, 1, 1)
        },
        new()
        {
            Id = 3, Name = "Gold Premium", Description = "Premium experience with private guide and all activities.",
            Tier = PackageTier.Gold, BasePrice = 65000, PeakMultiplier = 1.4m,
            IncludesAccommodation = true, IncludesMeals = true, IncludesTransfers = true,
            IncludesGameDrives = true, IncludesParkEntry = true, IncludesGuide = true,
            IsActive = true, CreatedAt = new DateTime(2024, 1, 1)
        },
        new()
        {
            Id = 4, Name = "Platinum Luxury", Description = "Ultimate luxury safari with VIP treatment throughout.",
            Tier = PackageTier.Platinum, BasePrice = 120000, PeakMultiplier = 1.5m,
            IncludesAccommodation = true, IncludesMeals = true, IncludesTransfers = true,
            IncludesGameDrives = true, IncludesParkEntry = true, IncludesGuide = true,
            IsActive = true, CreatedAt = new DateTime(2024, 1, 1)
        },
        new()
        {
            Id = 5, Name = "Bronze Day Trip", Description = "Affordable day visit with park entry and lunch.",
            Tier = PackageTier.Bronze, BasePrice = 5000, PeakMultiplier = 1.1m,
            IncludesAccommodation = false, IncludesMeals = true, IncludesTransfers = false,
            IncludesGameDrives = false, IncludesParkEntry = true, IncludesGuide = false,
            IsActive = true, CreatedAt = new DateTime(2024, 2, 1)
        }
    };

    private int _nextId = 6;

    public Task<List<Package>> GetPackagesAsync() =>
        Task.FromResult(_packages.ToList());

    public Task<Package?> GetPackageAsync(int id) =>
        Task.FromResult(_packages.FirstOrDefault(p => p.Id == id));

    public Task<Package> CreatePackageAsync(Package package)
    {
        package.Id = _nextId++;
        package.CreatedAt = DateTime.Now;
        _packages.Add(package);
        return Task.FromResult(package);
    }

    public Task<Package> UpdatePackageAsync(Package package)
    {
        var existing = _packages.FirstOrDefault(p => p.Id == package.Id);
        if (existing is null) return Task.FromResult(package);
        var index = _packages.IndexOf(existing);
        _packages[index] = package;
        return Task.FromResult(package);
    }

    public Task<bool> DeletePackageAsync(int id)
    {
        var package = _packages.FirstOrDefault(p => p.Id == id);
        if (package is null) return Task.FromResult(false);
        package.IsActive = false;
        return Task.FromResult(true);
    }

    public Task<List<Package>> GetPackagesByTierAsync(PackageTier tier) =>
        Task.FromResult(_packages.Where(p => p.Tier == tier).ToList());
}
