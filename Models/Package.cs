namespace BookingBackendWebApp.Models;

public enum PackageTier
{
    Bronze,
    Silver,
    Gold,
    Platinum
}

public class Package
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PackageTier Tier { get; set; }
    public decimal BasePrice { get; set; }
    public decimal PeakMultiplier { get; set; }
    public bool IncludesAccommodation { get; set; }
    public bool IncludesMeals { get; set; }
    public bool IncludesTransfers { get; set; }
    public bool IncludesGameDrives { get; set; }
    public bool IncludesParkEntry { get; set; }
    public bool IncludesGuide { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
