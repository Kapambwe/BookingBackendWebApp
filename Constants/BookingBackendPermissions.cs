namespace BookingBackendWebApp.Constants;

public static class BookingBackendPermissions
{
    public const string BookingCreate = "Booking.Create";
    public const string BookingEdit = "Booking.Edit";
    public const string BookingCancel = "Booking.Cancel";
    public const string BookingViewAll = "Booking.ViewAll";

    public const string PackageManage = "Package.Manage";
    public const string AccommodationManage = "Accommodation.Manage";
    public const string HousekeepingManage = "Housekeeping.Manage";
    public const string ParkEntryManage = "ParkEntry.Manage";
    public const string ActivityManage = "Activity.Manage";
    public const string TourOperatorManage = "TourOperator.Manage";
    public const string TransportManage = "Transport.Manage";
    public const string EventManage = "Event.Manage";
    public const string PosOperate = "Pos.Operate";

    public const string ConservationView = "Conservation.View";
    public const string ConservationManage = "Conservation.Manage";

    public const string RangerManage = "Ranger.Manage";
    public const string RevenueManagementView = "RevenueManagement.View";
    public const string RevenueManagementManage = "RevenueManagement.Manage";
    public const string GovernmentIntelligenceView = "GovernmentIntelligence.View";
    public const string AiAgentUse = "AiAgent.Use";

    public static string[] GetAllPermissions()
    {
        return new[]
        {
            BookingCreate,
            BookingEdit,
            BookingCancel,
            BookingViewAll,
            PackageManage,
            AccommodationManage,
            HousekeepingManage,
            ParkEntryManage,
            ActivityManage,
            TourOperatorManage,
            TransportManage,
            EventManage,
            PosOperate,
            ConservationView,
            ConservationManage,
            RangerManage,
            RevenueManagementView,
            RevenueManagementManage,
            GovernmentIntelligenceView,
            AiAgentUse
        };
    }
}
