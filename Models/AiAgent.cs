namespace BookingBackendWebApp.Models;

public class AiQueryRequest
{
    public string Query { get; set; } = string.Empty;
}

public class AiQueryResponse
{
    public string Answer { get; set; } = string.Empty;
    public Dictionary<string, object> Data { get; set; } = new();
}
