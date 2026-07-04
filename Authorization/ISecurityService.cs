namespace BookingBackendWebApp.Authorization;

public interface ISecurityService
{
    Task<bool> HasPermissionAsync(string permission);

    Task<bool> HasAllPermissionsAsync(string[] permissions);

    Task<bool> HasAnyPermissionAsync(string[] permissions);

    Task<bool> HasRoleAsync(string role);

    Task<bool> HasAnyRoleAsync(string[] roles);

    Task<IEnumerable<string>> GetUserPermissionsAsync();

    Task<IEnumerable<string>> GetUserRolesAsync();
}
