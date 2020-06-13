using PuppeteerSharp;
using System.IO;
using System.Threading.Tasks;

namespace jory.abp.BackgroundJobs.Jobs.PuppeteerTest
{
    public class PuppeteerTestJob : IBackgroundJob
    {
        public async Task ExecuteAsync()
        {
            var path = Path.Combine(Path.GetTempPath(), "jory.png");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] { "--no-sandbox" }
            });

            await using var page = await browser.NewPageAsync();

            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1920,
                Height = 1080
            });

            var url = "https://dotnet.cnblogs.com";
            await page.GoToAsync(url, WaitUntilNavigation.Networkidle0);

            var content = await page.GetContentAsync();

            await page.PdfAsync("jory.pdf");

            await page.ScreenshotAsync(path, new ScreenshotOptions
            {
                FullPage = true,
                Type = ScreenshotType.Png
            });

            //// 发送带图片的Email
            //var builder = new BodyBuilder();

            //var image = builder.LinkedResources.Add(path);
            //image.ContentId = MimeUtils.GenerateMessageId();

            //builder.HtmlBody = "当前时间:{0}.<img src=\"cid:{1}\"/>".FormatWith(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), image.ContentId);

            //var message = new MimeMessage
            //{
            //    Subject = "【定时任务】带图片的邮件推送",
            //    Body = builder.ToMessageBody()
            //};
            //await EmailHelper.SendAsync(message);
        }
    }
}
