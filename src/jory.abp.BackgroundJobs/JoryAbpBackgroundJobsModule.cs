using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.SqlServer;
using jory.abp.Domain.Configurations;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace jory.abp.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class JoryAbpBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new SqlServerStorage(AppSettings.ConnectionStrings,
                        new SqlServerStorageOptions
                        {
                            //T = JoryAbpConsts.DbTablePrefix + "hangfire"
                        }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            var service = context.ServiceProvider;

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new []
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = AppSettings.Hangfire.Login,
                                PasswordClear =  AppSettings.Hangfire.Password
                            }
                        }
                    })
                },
                DashboardTitle = "任务调度中心"
            });
            //service.UseHangfireTest();

            //service.UseWallpaperJob();

            //service.UseHotNewsJob();

            //service.UsePuppeteerTestJob();
        }
    }
}
