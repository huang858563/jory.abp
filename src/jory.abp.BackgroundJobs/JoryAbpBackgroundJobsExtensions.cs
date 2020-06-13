using Hangfire;
using jory.abp.BackgroundJobs.Jobs.Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using jory.abp.BackgroundJobs.Jobs.HotNews;
using jory.abp.BackgroundJobs.Jobs.PuppeteerTest;
using jory.abp.BackgroundJobs.Jobs.Wallpapers;

namespace jory.abp.BackgroundJobs
{
    public static class JoryAbpBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());
        }

        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();
            //RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Day(1, 1, 1));

            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Minute(3));
        }

        /// <summary>
        /// 每日热点数据抓取
        /// </summary>
        /// <param name="service"></param>
        public static void UseHotNewsJob(this IServiceProvider service)
        {
            var job = service.GetService<HotNewsJob>();

            RecurringJob.AddOrUpdate("每日热点数据抓取", () => job.ExecuteAsync(), CronType.Day(1, 1,7));
        }

        public static void UsePuppeteerTestJob(this IServiceProvider service)
        {
            var job = service.GetService<PuppeteerTestJob>();

            BackgroundJob.Enqueue(() => job.ExecuteAsync());
        }
    }
}
