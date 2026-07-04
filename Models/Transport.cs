namespace BookingBackendWebApp.Models;

public enum VehicleType
{
    SafariVehicle,
    Boat,
    Bus,
    Car
}

public enum VehicleStatus
{
    Available,
    InUse,
    Maintenance,
    OutOfService
}

public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public int Capacity { get; set; }
    public string FuelType { get; set; } = string.Empty;
    public VehicleStatus Status { get; set; }
    public double FuelLevel { get; set; }
    public DateTime? LastServiceDate { get; set; }
    public DateTime? NextServiceDue { get; set; }
}

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
}

public class FuelLog
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public decimal Liters { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
    public int Odometer { get; set; }
}

public class TransportSchedule
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int DriverId { get; set; }
    public string Route { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}
