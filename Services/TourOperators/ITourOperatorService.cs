namespace BookingBackendWebApp.Services.TourOperators;

using BookingBackendWebApp.Models;

public interface ITourOperatorService
{
    Task<List<TourOperator>> GetOperatorsAsync();
    Task<TourOperator?> GetOperatorAsync(int id);
    Task<TourOperator> CreateOperatorAsync(TourOperator op);
    Task<TourOperator> UpdateOperatorAsync(TourOperator op);
    Task<bool> ToggleOperatorStatusAsync(int id);
    Task<List<CommissionConfig>> GetCommissionConfigsAsync();
    Task<CommissionConfig> UpdateCommissionConfigAsync(CommissionConfig config);
    Task<List<Settlement>> GetSettlementsAsync();
    Task<Settlement> CreateSettlementAsync(Settlement settlement);
    Task<bool> ApproveSettlementAsync(int id);
}
