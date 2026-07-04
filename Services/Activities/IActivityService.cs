namespace BookingBackendWebApp.Services.Activities;

using BookingBackendWebApp.Models;

public interface IActivityService
{
    Task<List<Activity>> GetActivitiesAsync();
    Task<Activity?> GetActivityAsync(int id);
    Task<Activity> CreateActivityAsync(Activity activity);
    Task<Activity> UpdateActivityAsync(Activity activity);
    Task<bool> DeleteActivityAsync(int id);
    Task<List<Activity>> GetActivitiesByTypeAsync(ActivityType type);
    Task<List<Guide>> GetGuidesAsync();
    Task<Guide> CreateGuideAsync(Guide guide);
    Task<bool> AssignGuideAsync(int activityId, int guideId);
    Task<List<ActivitySchedule>> GetSchedulesAsync(DateTime date);
    Task<ActivitySchedule> CreateScheduleAsync(ActivitySchedule schedule);
}
