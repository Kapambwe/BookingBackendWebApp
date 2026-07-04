namespace BookingBackendWebApp.Services;

using BookingBackendWebApp.Models;

public class TourismDataLoader
{
    public Task<List<Booking>> GetBookingsAsync() =>
        Task.FromResult(new List<Booking>
        {
            new()
            {
                Id = 1, BookingNumber = "BK-2024-001", BookingType = BookingType.Room,
                Status = BookingStatus.Confirmed, GuestName = "John Doe",
                GuestEmail = "john@example.com", GuestPhone = "+254700111222",
                Nationality = "Kenyan", CheckInDate = DateTime.Today.AddDays(-2),
                CheckOutDate = DateTime.Today.AddDays(3), Adults = 2, Children = 1,
                TotalAmount = 45000, PaidAmount = 22500, BalanceAmount = 22500,
                PackageId = 1, RoomId = 101, CreatedAt = DateTime.Today.AddDays(-10)
            }
        });

    public Task<List<Package>> GetPackagesAsync() =>
        Task.FromResult(new List<Package>
        {
            new()
            {
                Id = 1, Name = "Bronze Safari", Description = "Basic safari experience",
                Tier = PackageTier.Bronze, BasePrice = 15000, PeakMultiplier = 1.2m,
                IncludesAccommodation = true, IncludesMeals = true, IsActive = true,
                CreatedAt = DateTime.Today.AddMonths(-6)
            }
        });

    public Task<List<Room>> GetRoomsAsync() =>
        Task.FromResult(new List<Room>());

    public Task<List<Activity>> GetActivitiesAsync() =>
        Task.FromResult(new List<Activity>());

    public Task<List<TourOperator>> GetTourOperatorsAsync() =>
        Task.FromResult(new List<TourOperator>());

    public Task<List<Vehicle>> GetVehiclesAsync() =>
        Task.FromResult(new List<Vehicle>());

    public Task<List<Venue>> GetVenuesAsync() =>
        Task.FromResult(new List<Venue>());

    public Task<List<PosMenuItem>> GetPosMenuItemsAsync() =>
        Task.FromResult(new List<PosMenuItem>());

    public Task<List<Species>> GetSpeciesAsync() =>
        Task.FromResult(new List<Species>());

    public Task<List<Ranger>> GetRangersAsync() =>
        Task.FromResult(new List<Ranger>());

    public Task<List<PricingRule>> GetPricingRulesAsync() =>
        Task.FromResult(new List<PricingRule>());

    public Task<List<GovernmentKpi>> GetGovernmentKpisAsync() =>
        Task.FromResult(new List<GovernmentKpi>());
}
