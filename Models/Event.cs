namespace BookingBackendWebApp.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Location { get; set; } = string.Empty;
    public bool HasCatering { get; set; }
    public bool HasEquipment { get; set; }
    public decimal HourlyRate { get; set; }
    public bool IsAvailable { get; set; }
}

public class EventBooking
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public string Organizer { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int AttendeeCount { get; set; }
    public bool CateringRequired { get; set; }
    public List<string> EquipmentList { get; set; } = new();
    public decimal TotalCost { get; set; }
    public string Status { get; set; } = string.Empty;
}
