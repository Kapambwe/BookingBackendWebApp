namespace BookingBackendWebApp.Services.TourOperators;

using BookingBackendWebApp.Models;

public class MockTourOperatorService : ITourOperatorService
{
    private readonly List<TourOperator> _operators = new()
    {
        new() { Id = 1, Name = "Safari Seekers Ltd", ContactPerson = "James Omondi", Email = "james@safariseekers.co.ke", Phone = "+254722100001", CommissionRate = 0.15m, IsActive = true, TotalBookings = 45, TotalRevenue = 2500000 },
        new() { Id = 2, Name = "Wild Trails Africa", ContactPerson = "Sarah Kibathi", Email = "sarah@wildtrails.africa", Phone = "+254733200002", CommissionRate = 0.12m, IsActive = true, TotalBookings = 32, TotalRevenue = 1800000 },
        new() { Id = 3, Name = "Kenya Pathways", ContactPerson = "Peter Njenga", Email = "peter@kenyapathways.com", Phone = "+254744300003", CommissionRate = 0.18m, IsActive = false, TotalBookings = 12, TotalRevenue = 800000 },
        new() { Id = 4, Name = "Equator Expeditions", ContactPerson = "Mary Wambui", Email = "mary@equatorexp.co.ke", Phone = "+254755400004", CommissionRate = 0.10m, IsActive = true, TotalBookings = 28, TotalRevenue = 1500000 }
    };

    private readonly List<CommissionConfig> _commissions = new()
    {
        new() { Id = 1, OperatorId = 1, Rate = 0.15m, EffectiveFrom = new DateTime(2024, 1, 1) },
        new() { Id = 2, OperatorId = 2, Rate = 0.12m, EffectiveFrom = new DateTime(2024, 1, 1) },
        new() { Id = 3, OperatorId = 4, Rate = 0.10m, EffectiveFrom = new DateTime(2024, 1, 1) }
    };

    private readonly List<Settlement> _settlements = new()
    {
        new() { Id = 1, OperatorId = 1, PeriodStart = new DateTime(2024, 5, 1), PeriodEnd = new DateTime(2024, 5, 31), TotalCommission = 75000, PaidAmount = 0, Status = "Pending" },
        new() { Id = 2, OperatorId = 2, PeriodStart = new DateTime(2024, 5, 1), PeriodEnd = new DateTime(2024, 5, 31), TotalCommission = 42000, PaidAmount = 42000, Status = "Approved" }
    };

    private int _nextOperatorId = 5;
    private int _nextSettlementId = 3;

    public Task<List<TourOperator>> GetOperatorsAsync() => Task.FromResult(_operators.ToList());
    public Task<TourOperator?> GetOperatorAsync(int id) => Task.FromResult(_operators.FirstOrDefault(o => o.Id == id));
    public Task<TourOperator> CreateOperatorAsync(TourOperator op) { op.Id = _nextOperatorId++; _operators.Add(op); return Task.FromResult(op); }
    public Task<TourOperator> UpdateOperatorAsync(TourOperator op)
    {
        var i = _operators.FindIndex(o => o.Id == op.Id);
        if (i >= 0) _operators[i] = op;
        return Task.FromResult(op);
    }
    public Task<bool> ToggleOperatorStatusAsync(int id)
    {
        var op = _operators.FirstOrDefault(o => o.Id == id);
        if (op is null) return Task.FromResult(false);
        op.IsActive = !op.IsActive;
        return Task.FromResult(true);
    }
    public Task<List<CommissionConfig>> GetCommissionConfigsAsync() => Task.FromResult(_commissions.ToList());
    public Task<CommissionConfig> UpdateCommissionConfigAsync(CommissionConfig config)
    {
        var i = _commissions.FindIndex(c => c.Id == config.Id);
        if (i >= 0) _commissions[i] = config;
        return Task.FromResult(config);
    }
    public Task<List<Settlement>> GetSettlementsAsync() => Task.FromResult(_settlements.ToList());
    public Task<Settlement> CreateSettlementAsync(Settlement settlement)
    {
        settlement.Id = _nextSettlementId++;
        _settlements.Add(settlement);
        return Task.FromResult(settlement);
    }
    public Task<bool> ApproveSettlementAsync(int id)
    {
        var s = _settlements.FirstOrDefault(s => s.Id == id);
        if (s is null) return Task.FromResult(false);
        s.Status = "Approved";
        return Task.FromResult(true);
    }
}
