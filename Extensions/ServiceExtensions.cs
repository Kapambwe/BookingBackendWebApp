using BookingBackendWebApp.Constants;
using CompanyApp.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace BookingBackendWebApp.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPermissionAuthorization(
        this IServiceCollection services,
        IEnumerable<string>? permissionsToPreload = null)
    {
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

        services.AddAuthorizationCore(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            AddBookingPolicies(options);
            AddPermissionPolicies(options, permissionsToPreload);
        });

        return services;
    }

    private static void AddBookingPolicies(AuthorizationOptions options)
    {
        options.AddPolicy("BookingCreate", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.BookingCreate)));

        options.AddPolicy("BookingEdit", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.BookingEdit)));

        options.AddPolicy("BookingCancel", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.BookingCancel)));

        options.AddPolicy("BookingViewAll", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.BookingViewAll)));

        options.AddPolicy("PackageManage", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.PackageManage)));

        options.AddPolicy("AccommodationManage", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.AccommodationManage)));

        options.AddPolicy("PosOperate", policy =>
            policy.Requirements.Add(new PermissionRequirement(BookingBackendPermissions.PosOperate)));
    }

    private static void AddPermissionPolicies(
        AuthorizationOptions options,
        IEnumerable<string>? permissionsToPreload)
    {
        if (permissionsToPreload is null)
            return;

        foreach (var permission in permissionsToPreload
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Distinct(StringComparer.Ordinal))
        {
            options.AddPolicy(GetPolicyName(permission), policy =>
                policy.RequireAuthenticatedUser()
                    .AddRequirements(new PermissionRequirement(permission)));
        }
    }

    public static string GetPolicyName(string permission)
    {
        return $"Permission:{permission}";
    }
}
