namespace BookingBackendWebApp.Services.AiAgent;

using BookingBackendWebApp.Models;

public class MockAiAgentService : IAiAgentService
{
    private readonly List<AiQueryResponse> _history = new();

    private static readonly Dictionary<string, string> MockResponses = new(StringComparer.OrdinalIgnoreCase)
    {
        ["occupancy"] = "Current occupancy is at 72%. Peak season (July-September) typically sees 85-90% occupancy. I recommend adjusting pricing for optimal yield.",
        ["pricing"] = "Based on current market analysis, the optimal price point for standard rooms is KES 8,000-12,000 per night. Premium rooms can command KES 15,000-25,000.",
        ["forecast"] = "Next month's forecast projects 78% occupancy with estimated revenue of KES 3.2M. This is a 12% increase from the same period last year.",
        ["conservation"] = "The park's elephant population has increased by 5% this year. The black rhino sanctuary program shows promising results with 3 new births recorded.",
        ["booking"] = "Total active bookings: 127. Check-ins today: 18. Check-outs today: 14. Revenue pipeline: KES 4.5M for the next 30 days."
    };

    public Task<AiQueryResponse> AskAsync(AiQueryRequest request)
    {
        var answer = "I'm a mock AI assistant for park management. I can help with occupancy, pricing, forecasting, conservation, and booking inquiries.";

        foreach (var (keyword, response) in MockResponses)
        {
            if (request.Query.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                answer = response;
                break;
            }
        }

        var responseObj = new AiQueryResponse
        {
            Answer = answer
        };

        _history.Add(responseObj);
        return Task.FromResult(responseObj);
    }

    public Task<List<AiQueryResponse>> GetHistoryAsync() =>
        Task.FromResult(_history.ToList());

    public Task<bool> ClearHistoryAsync()
    {
        _history.Clear();
        return Task.FromResult(true);
    }
}
