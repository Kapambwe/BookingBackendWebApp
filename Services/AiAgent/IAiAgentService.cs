namespace BookingBackendWebApp.Services.AiAgent;

using BookingBackendWebApp.Models;

public interface IAiAgentService
{
    Task<AiQueryResponse> AskAsync(AiQueryRequest request);
    Task<List<AiQueryResponse>> GetHistoryAsync();
    Task<bool> ClearHistoryAsync();
}
