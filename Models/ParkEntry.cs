namespace BookingBackendWebApp.Models;

public enum VisitorCategory
{
    Adult,
    Child,
    Student,
    Senior
}

public enum PricingTier
{
    Citizen,
    Resident,
    International
}

public enum PassType
{
    Daily,
    Weekly,
    Annual
}

public class ParkEntryPricing
{
    public int Id { get; set; }
    public VisitorCategory VisitorCategory { get; set; }
    public PricingTier PricingTier { get; set; }
    public decimal DailyRate { get; set; }
    public decimal WeeklyRate { get; set; }
    public decimal AnnualRate { get; set; }
    public decimal VehicleFee { get; set; }
    public decimal BoatFee { get; set; }
    public decimal DronePermitFee { get; set; }
    public decimal PhotographyPermitFee { get; set; }
    public decimal FilmPermitFee { get; set; }
}

public class ParkPermit
{
    public int Id { get; set; }
    public string PermitType { get; set; } = string.Empty;
    public string Holder { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; } = DateTime.Today;
    public DateTime ExpiryDate { get; set; } = DateTime.Today.AddYears(1);
    public decimal Fee { get; set; }
}

public class ParkPass
{
    public int Id { get; set; }
    public string PassNumber { get; set; } = string.Empty;
    public string VisitorName { get; set; } = string.Empty;
    public PassType PassType { get; set; }
    public int PricingTierId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public decimal Fee { get; set; }
}
