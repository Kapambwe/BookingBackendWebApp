using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BookingBackendWebApp.Authorization;

public class SecurityService : ISecurityService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public SecurityService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> HasPermissionAsync(string permission)
    {
        if (string.IsNullOrWhiteSpace(permission))
            return false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        return user.HasClaim(c => c.Type == "permission" && c.Value.Equals(permission, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> HasAllPermissionsAsync(string[] permissions)
    {
        if (permissions == null || permissions.Length == 0)
            return false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        var userPermissions = user.Claims
            .Where(c => c.Type == "permission")
            .Select(c => c.Value)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return permissions.All(p => userPermissions.Contains(p));
    }

    public async Task<bool> HasAnyPermissionAsync(string[] permissions)
    {
        if (permissions == null || permissions.Length == 0)
            return false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        var userPermissions = user.Claims
            .Where(c => c.Type == "permission")
            .Select(c => c.Value)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return permissions.Any(p => userPermissions.Contains(p));
    }

    public async Task<bool> HasRoleAsync(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            return false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        return user.IsInRole(role);
    }

    public async Task<bool> HasAnyRoleAsync(string[] roles)
    {
        if (roles == null || roles.Length == 0)
            return false;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return false;

        return roles.Any(role => user.IsInRole(role));
    }

    public async Task<IEnumerable<string>> GetUserPermissionsAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return Enumerable.Empty<string>();

        return user.Claims
            .Where(c => c.Type == "permission")
            .Select(c => c.Value)
            .Distinct()
            .ToList();
    }

    public async Task<IEnumerable<string>> GetUserRolesAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            return Enumerable.Empty<string>();

        return user.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct()
            .ToList();
    }
}
