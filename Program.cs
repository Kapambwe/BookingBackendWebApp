using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using BookingBackendWebApp;
using BookingBackendWebApp.Extensions;
using BookingBackendWebApp.Services;
using BookingBackendWebApp.Services.Bookings;
using BookingBackendWebApp.Services.Packages;
using BookingBackendWebApp.Services.Accommodation;
using BookingBackendWebApp.Services.ParkEntry;
using BookingBackendWebApp.Services.Activities;
using BookingBackendWebApp.Services.TourOperators;
using BookingBackendWebApp.Services.Transport;
using BookingBackendWebApp.Services.Events;
using BookingBackendWebApp.Services.Pos;
using BookingBackendWebApp.Services.Conservation;
using BookingBackendWebApp.Services.Rangers;
using BookingBackendWebApp.Services.RevenueManagement;
using BookingBackendWebApp.Services.GovernmentIntelligence;
using BookingBackendWebApp.Services.AiAgent;
using CompanyApp.Shared.Authorization;
using BookingBackendWebApp.Constants;
using BookingBackendWebApp.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddPermissionAuthorization(BookingBackendPermissions.GetAllPermissions());
builder.Services.AddScoped<AuthenticationStateProvider, MockAuthenticationStateProvider>();
builder.Services.AddScoped<MockAuthenticationStateProvider>(sp =>
    (MockAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddScoped<ISecurityService, SecurityService>();

builder.Services.AddScoped<TourismDataLoader>();

builder.Services.AddScoped<IBookingService, MockBookingService>();
builder.Services.AddScoped<IPackageService, MockPackageService>();
builder.Services.AddScoped<IAccommodationService, MockAccommodationService>();
builder.Services.AddScoped<IParkEntryService, MockParkEntryService>();
builder.Services.AddScoped<IActivityService, MockActivityService>();
builder.Services.AddScoped<ITourOperatorService, MockTourOperatorService>();
builder.Services.AddScoped<ITransportService, MockTransportService>();
builder.Services.AddScoped<IEventService, MockEventService>();
builder.Services.AddScoped<IPosService, MockPosService>();
builder.Services.AddScoped<IConservationService, MockConservationService>();
builder.Services.AddScoped<IRangerService, MockRangerService>();
builder.Services.AddScoped<IRevenueManagementService, MockRevenueManagementService>();
builder.Services.AddScoped<IGovernmentIntelligenceService, MockGovernmentIntelligenceService>();
builder.Services.AddScoped<IAiAgentService, MockAiAgentService>();

await builder.Build().RunAsync();
