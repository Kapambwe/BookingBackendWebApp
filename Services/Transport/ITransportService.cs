namespace BookingBackendWebApp.Services.Transport;

using BookingBackendWebApp.Models;

public interface ITransportService
{
    Task<List<Vehicle>> GetVehiclesAsync();
    Task<Vehicle?> GetVehicleAsync(int id);
    Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
    Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    Task<bool> ToggleVehicleStatusAsync(int id);
    Task<List<Driver>> GetDriversAsync();
    Task<Driver> CreateDriverAsync(Driver driver);
    Task<bool> AssignDriverAsync(int vehicleId, int driverId);
    Task<List<TransportSchedule>> GetSchedulesAsync(DateTime date);
    Task<TransportSchedule> CreateScheduleAsync(TransportSchedule schedule);
    Task<bool> CompleteTripAsync(int id);
    Task<List<FuelLog>> GetFuelLogsAsync();
    Task<FuelLog> AddFuelLogAsync(FuelLog log);
}
