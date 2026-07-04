namespace BookingBackendWebApp.Models;

public enum AdjustmentType
{
    Percentage,
    Fixed
}

public class PricingRule
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public AdjustmentType AdjustmentType { get; set; }
    public decimal AdjustmentValue { get; set; }
    public bool IsActive { get; set; }
}

public class Forecast
{
    public int Id { get; set; }
    public string Period { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
    public double Occupancy { get; set; }
    public int VisitorCount { get; set; }
    public double Confidence { get; set; }
}
