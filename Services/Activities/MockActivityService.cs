namespace BookingBackendWebApp.Services.Activities;

using BookingBackendWebApp.Models;

public class MockActivityService : IActivityService
{
    private readonly List<Activity> _activities = new()
    {
        new() { Id = 1, Name = "Morning Game Drive", Type = ActivityType.GameDrive, Duration = 4, Capacity = 8, BasePrice = 5000, Description = "Early morning wildlife viewing" },
        new() { Id = 2, Name = "Sunset Game Drive", Type = ActivityType.GameDrive, Duration = 3, Capacity = 8, BasePrice = 6000, Description = "Evening wildlife viewing" },
        new() { Id = 3, Name = "Guided Bush Walk", Type = ActivityType.WalkingSafari, Duration = 2, Capacity = 6, BasePrice = 3000, Description = "Walk with experienced ranger" },
        new() { Id = 4, Name = "Boat Cruise", Type = ActivityType.Canoeing, Duration = 2, Capacity = 12, BasePrice = 4000, Description = "River cruise with bird watching" },
        new() { Id = 5, Name = "Bird Watching Tour", Type = ActivityType.BirdWatching, Duration = 3, Capacity = 6, BasePrice = 3500, Description = "Expert-guided bird identification" },
        new() { Id = 6, Name = "Photography Safari", Type = ActivityType.ConservationTour, Duration = 5, Capacity = 4, BasePrice = 10000, Description = "Dedicated photography expedition" }
    };

    private readonly List<Guide> _guides = new()
    {
        new() { Id = 1, Name = "Joseph Lekishon", Specialization = "Wildlife", IsAvailable = true },
        new() { Id = 2, Name = "Grace Akinyi", Specialization = "Birding", IsAvailable = true },
        new() { Id = 3, Name = "Samuel Ole Nchoe", Specialization = "Bush Walks", IsAvailable = true },
        new() { Id = 4, Name = "Diana Waithera", Specialization = "Photography", IsAvailable = false }
    };

    private readonly List<ActivitySchedule> _schedules = new()
    {
        new() { Id = 1, ActivityId = 1, GuideId = 1, ScheduledDate = DateTime.Today, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(10, 0, 0), Capacity = 8, BookedCount = 4 },
        new() { Id = 2, ActivityId = 2, GuideId = 2, ScheduledDate = DateTime.Today, StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(18, 0, 0), Capacity = 8, BookedCount = 6 },
        new() { Id = 3, ActivityId = 3, GuideId = 3, ScheduledDate = DateTime.Today.AddDays(1), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(10, 0, 0), Capacity = 6, BookedCount = 2 }
    };

    private int _nextActivityId = 7;
    private int _nextGuideId = 5;
    private int _nextScheduleId = 4;

    public Task<List<Activity>> GetActivitiesAsync() => Task.FromResult(_activities.ToList());
    public Task<Activity?> GetActivityAsync(int id) => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
    public Task<Activity> CreateActivityAsync(Activity activity) { activity.Id = _nextActivityId++; _activities.Add(activity); return Task.FromResult(activity); }
    public Task<Activity> UpdateActivityAsync(Activity activity)
    {
        var i = _activities.FindIndex(a => a.Id == activity.Id);
        if (i >= 0) _activities[i] = activity;
        return Task.FromResult(activity);
    }
    public Task<bool> DeleteActivityAsync(int id)
    {
        var a = _activities.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(_activities.Remove(a!));
    }
    public Task<List<Activity>> GetActivitiesByTypeAsync(ActivityType type) =>
        Task.FromResult(_activities.Where(a => a.Type == type).ToList());
    public Task<List<Guide>> GetGuidesAsync() => Task.FromResult(_guides.ToList());
    public Task<Guide> CreateGuideAsync(Guide guide) { guide.Id = _nextGuideId++; _guides.Add(guide); return Task.FromResult(guide); }
    public Task<bool> AssignGuideAsync(int activityId, int guideId)
    {
        var s = _schedules.FirstOrDefault(s => s.ActivityId == activityId);
        if (s is null) return Task.FromResult(false);
        s.GuideId = guideId;
        return Task.FromResult(true);
    }
    public Task<List<ActivitySchedule>> GetSchedulesAsync(DateTime date) =>
        Task.FromResult(_schedules.Where(s => s.ScheduledDate.Date == date.Date).ToList());
    public Task<ActivitySchedule> CreateScheduleAsync(ActivitySchedule schedule)
    {
        schedule.Id = _nextScheduleId++;
        _schedules.Add(schedule);
        return Task.FromResult(schedule);
    }
}
