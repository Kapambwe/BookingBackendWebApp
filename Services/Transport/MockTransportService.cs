namespace BookingBackendWebApp.Services.Transport;

using BookingBackendWebApp.Models;

public class MockTransportService : ITransportService
{
    private readonly List<Vehicle> _vehicles = new()
    {
        new() { Id = 1, Name = "Toyota Land Cruiser", RegistrationNumber = "KCA 001T", Capacity = 8, VehicleType = VehicleType.SafariVehicle, Status = VehicleStatus.Available, FuelType = "Diesel", FuelLevel = 0.75, LastServiceDate = DateTime.Today.AddMonths(-1), NextServiceDue = DateTime.Today.AddMonths(1) },
        new() { Id = 2, Name = "Toyota Land Cruiser", RegistrationNumber = "KCB 002T", Capacity = 8, VehicleType = VehicleType.SafariVehicle, Status = VehicleStatus.Available, FuelType = "Diesel", FuelLevel = 0.9, LastServiceDate = DateTime.Today.AddDays(-15), NextServiceDue = DateTime.Today.AddMonths(1) },
        new() { Id = 3, Name = "Toyota Hiace", RegistrationNumber = "KCC 003T", Capacity = 14, VehicleType = VehicleType.Bus, Status = VehicleStatus.InUse, FuelType = "Diesel", FuelLevel = 0.4, LastServiceDate = DateTime.Today.AddMonths(-2), NextServiceDue = DateTime.Today.AddDays(15) },
        new() { Id = 4, Name = "Nissan Patrol", RegistrationNumber = "KCD 004T", Capacity = 7, VehicleType = VehicleType.SafariVehicle, Status = VehicleStatus.Maintenance, FuelType = "Diesel", FuelLevel = 0.1, LastServiceDate = DateTime.Today.AddDays(-5), NextServiceDue = DateTime.Today.AddDays(-5) },
        new() { Id = 5, Name = "Isuzu Bus", RegistrationNumber = "KCE 005T", Capacity = 30, VehicleType = VehicleType.Bus, Status = VehicleStatus.Available, FuelType = "Diesel", FuelLevel = 0.6, LastServiceDate = DateTime.Today.AddMonths(-3), NextServiceDue = DateTime.Today.AddMonths(2) }
    };

    private readonly List<Driver> _drivers = new()
    {
        new() { Id = 1, Name = "Paul Mwangi", LicenseNumber = "DL-001", IsAvailable = true },
        new() { Id = 2, Name = "John Kiprop", LicenseNumber = "DL-002", IsAvailable = true },
        new() { Id = 3, Name = "Jane Akinyi", LicenseNumber = "DL-003", IsAvailable = false }
    };

    private readonly List<TransportSchedule> _schedules = new()
    {
        new() { Id = 1, VehicleId = 1, DriverId = 1, Route = "Lodge - Airstrip", Date = DateTime.Today, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(9, 0, 0), Status = "Scheduled" },
        new() { Id = 2, VehicleId = 3, DriverId = 2, Route = "Lodge - Park Gate", Date = DateTime.Today, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(10, 30, 0), Status = "InProgress" }
    };

    private readonly List<FuelLog> _fuelLogs = new()
    {
        new() { Id = 1, VehicleId = 1, Liters = 80, Cost = 14400, Date = DateTime.Today.AddDays(-2), Odometer = 45200 },
        new() { Id = 2, VehicleId = 2, Liters = 75, Cost = 13500, Date = DateTime.Today.AddDays(-1), Odometer = 23100 }
    };

    private int _nextVehicleId = 6;
    private int _nextDriverId = 4;
    private int _nextScheduleId = 3;
    private int _nextFuelLogId = 3;

    public Task<List<Vehicle>> GetVehiclesAsync() => Task.FromResult(_vehicles.ToList());
    public Task<Vehicle?> GetVehicleAsync(int id) => Task.FromResult(_vehicles.FirstOrDefault(v => v.Id == id));
    public Task<Vehicle> CreateVehicleAsync(Vehicle v) { v.Id = _nextVehicleId++; _vehicles.Add(v); return Task.FromResult(v); }
    public Task<Vehicle> UpdateVehicleAsync(Vehicle v)
    {
        var i = _vehicles.FindIndex(x => x.Id == v.Id);
        if (i >= 0) _vehicles[i] = v;
        return Task.FromResult(v);
    }
    public Task<bool> ToggleVehicleStatusAsync(int id)
    {
        var v = _vehicles.FirstOrDefault(v => v.Id == id);
        if (v is null) return Task.FromResult(false);
        v.Status = v.Status == VehicleStatus.Available ? VehicleStatus.Maintenance : VehicleStatus.Available;
        return Task.FromResult(true);
    }
    public Task<List<Driver>> GetDriversAsync() => Task.FromResult(_drivers.ToList());
    public Task<Driver> CreateDriverAsync(Driver d) { d.Id = _nextDriverId++; _drivers.Add(d); return Task.FromResult(d); }
    public Task<bool> AssignDriverAsync(int vehicleId, int driverId)
    {
        var s = _schedules.FirstOrDefault(s => s.VehicleId == vehicleId);
        if (s is null) return Task.FromResult(false);
        s.DriverId = driverId;
        return Task.FromResult(true);
    }
    public Task<List<TransportSchedule>> GetSchedulesAsync(DateTime date) =>
        Task.FromResult(_schedules.Where(s => s.Date.Date == date.Date).ToList());
    public Task<TransportSchedule> CreateScheduleAsync(TransportSchedule s)
    {
        s.Id = _nextScheduleId++; _schedules.Add(s); return Task.FromResult(s);
    }
    public Task<bool> CompleteTripAsync(int id)
    {
        var s = _schedules.FirstOrDefault(s => s.Id == id);
        if (s is null) return Task.FromResult(false);
        s.Status = "Completed";
        return Task.FromResult(true);
    }
    public Task<List<FuelLog>> GetFuelLogsAsync() => Task.FromResult(_fuelLogs.ToList());
    public Task<FuelLog> AddFuelLogAsync(FuelLog log)
    {
        log.Id = _nextFuelLogId++; _fuelLogs.Add(log); return Task.FromResult(log);
    }
}
