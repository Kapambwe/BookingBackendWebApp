namespace BookingBackendWebApp.Models;

public class TourOperator
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal CommissionRate { get; set; }
    public bool IsActive { get; set; }
    public int TotalBookings { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class CommissionConfig
{
    public int Id { get; set; }
    public int OperatorId { get; set; }
    public decimal Rate { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}

public class Settlement
{
    public int Id { get; set; }
    public int OperatorId { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public decimal TotalCommission { get; set; }
    public decimal PaidAmount { get; set; }
    public string Status { get; set; } = string.Empty;
}
