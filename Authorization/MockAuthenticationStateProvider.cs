using BookingBackendWebApp.Constants;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BookingBackendWebApp.Authorization;

public class MockAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public bool IsAuthenticated => _currentUser.Identity?.IsAuthenticated ?? false;

    public Guid? CurrentTenantId
    {
        get
        {
            var tenantClaim = _currentUser.Claims.FirstOrDefault(c => c.Type == "TenantId");
            if (tenantClaim != null && Guid.TryParse(tenantClaim.Value, out var tenantId))
                return tenantId;
            return null;
        }
    }

    public void SetAuthenticatedUser(string username, string role, Guid? tenantId = null)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, username),
            new(ClaimTypes.Role, role),
            new("TenantId", (tenantId ?? Guid.Parse("00000000-0000-0000-0000-000000000001")).ToString())
        };

        var permissions = BookingBackendPermissions.GetAllPermissions();
        foreach (var permission in permissions)
        {
            claims.Add(new Claim("permission", permission));
        }

        var identity = new ClaimsIdentity(claims, "Mock authentication");
        _currentUser = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void SetAuthenticatedUser(string username, string role)
    {
        SetAuthenticatedUser(username, role, Guid.Parse("00000000-0000-0000-0000-000000000001"));
    }

    public void LoginAsAdmin()
    {
        SetAuthenticatedUser("admin@bookingbackend.com", "Admin");
    }

    public void SetAuthenticatedUserWithPermissions(string username, params string[] permissions)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, username)
        };

        foreach (var permission in permissions)
        {
            claims.Add(new Claim("permission", permission));
        }

        var identity = new ClaimsIdentity(claims, "Mock authentication");
        _currentUser = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public Task<AuthenticationState> LoginAsync(string username, string role, Guid? tenantId = null)
    {
        SetAuthenticatedUser(username, role, tenantId);
        return GetAuthenticationStateAsync();
    }

    public Task LogoutAsync()
    {
        Logout();
        return Task.CompletedTask;
    }

    public Task<AuthenticationState> LoginAsAdminAsync()
    {
        LoginAsAdmin();
        return GetAuthenticationStateAsync();
    }
}
