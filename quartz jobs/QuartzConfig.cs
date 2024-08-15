using Quartz;

using quartz_jobs.Jobs;

namespace quartz_jobs;

public static class QuartzConfig
{
   
        public static void ConfigureQuartz(IServiceCollectionQuartzConfigurator q)
        {
            var jobKey = new JobKey("TemperatureMonitoringJob");
            q.AddJob<TemperatureMonitoringJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("TemperatureMonitoringJob-trigger")
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever()));
    }
}

/* WithCalendarIntervalSchedule :

   q.AddTrigger(opts => opts
.ForJob(jobKey)
.WithIdentity("TemperatureMonitoringJob-trigger")
.WithCalendarIntervalSchedule(x => x
    .WithIntervalInDays(2)));
*/

/* WithCronSchedule : 
 
 q.AddTrigger(opts => opts
    .ForJob(jobKey)
    .WithIdentity("TemperatureMonitoringJob-trigger")
    .WithCronSchedule("0 30 14 * * ?"));  // CRON expression for 14:30 every day
*/

/* WithDailyTimeIntervalSchedule
q.AddTrigger(opts => opts
    .ForJob(jobKey)
    .WithIdentity("TemperatureMonitoringJob-trigger")
    .WithDailyTimeIntervalSchedule(x => x
        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(9, 0))
        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(17, 0))
        .WithIntervalInHours(2)));
*/


