namespace BookingBackendWebApp.Models;

public class GovernmentKpi
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Metric { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Period { get; set; } = string.Empty;
    public double PreviousValue { get; set; }
    public double Change { get; set; }
}

public class Scorecard
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public double BusinessHealthScore { get; set; }
    public double TourismCreditScore { get; set; }
    public double SustainabilityScore { get; set; }
    public double FinancingReadinessScore { get; set; }
    public string Period { get; set; } = string.Empty;
}
