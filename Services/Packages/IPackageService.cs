namespace BookingBackendWebApp.Services.Packages;

using BookingBackendWebApp.Models;

public interface IPackageService
{
    Task<List<Package>> GetPackagesAsync();
    Task<Package?> GetPackageAsync(int id);
    Task<Package> CreatePackageAsync(Package package);
    Task<Package> UpdatePackageAsync(Package package);
    Task<bool> DeletePackageAsync(int id);
    Task<List<Package>> GetPackagesByTierAsync(PackageTier tier);
}
