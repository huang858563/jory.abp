﻿using System;
using HtmlAgilityPack;
using jory.abp.Application.Contracts.Wallpaper;
using jory.abp.Domain.Shared.Enum;
using jory.abp.Domain.Wallpaper;
using jory.abp.Domain.Wallpaper.Repositories;
using jory.abp.ToolKits.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jory.abp.ToolKits.Helper;
using MimeKit;

namespace jory.abp.BackgroundJobs.Jobs.Wallpapers
{
    public class WallpaperJob : IBackgroundJob
    {
        private readonly IWallpaperRepository _wallpaperRepository;

        public WallpaperJob(IWallpaperRepository wallpaperRepository)
        {
            _wallpaperRepository = wallpaperRepository;
        }


        public async Task ExecuteAsync()
        {
            var wallpaperUrls = new List<WallpaperJobItem<string>>
            {
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_1_1.html", Type = WallpaperEnum.Beauty},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_58_1.html", Type = WallpaperEnum.Sportsman},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_66_1.html", Type = WallpaperEnum.CuteBaby},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_4_1.html", Type = WallpaperEnum.Emotion},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_3_1.html", Type = WallpaperEnum.Landscape},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_9_1.html", Type = WallpaperEnum.Animal},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_13_1.html", Type = WallpaperEnum.Plant},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_64_1.html", Type = WallpaperEnum.Food},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_11_1.html", Type = WallpaperEnum.Movie},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_5_1.html", Type = WallpaperEnum.Anime},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_34_1.html", Type = WallpaperEnum.HandPainted},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_65_1.html", Type = WallpaperEnum.Text},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_2_1.html", Type = WallpaperEnum.Creative},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_10_1.html", Type = WallpaperEnum.Car},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_14_1.html", Type = WallpaperEnum.PhysicalEducation},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_63_1.html", Type = WallpaperEnum.Military},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_17_1.html", Type = WallpaperEnum.Festival},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_15_1.html", Type = WallpaperEnum.Game},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_12_1.html", Type = WallpaperEnum.Apple},
                new WallpaperJobItem<string>
                    {Result = "https://www.i4.cn/wper_4_19_7_1.html", Type = WallpaperEnum.Other}
            };

            var web = new HtmlWeb();
            var listTask = new List<Task<WallpaperJobItem<HtmlDocument>>>();

            wallpaperUrls.ForEach(item =>
            {
                var task = Task.Run(async () =>
                {
                    var htmlDocument = await web.LoadFromWebAsync(item.Result);
                    return new WallpaperJobItem<HtmlDocument>
                    {
                        Result = htmlDocument,
                        Type = item.Type
                    };
                });
                listTask.Add(task);
            });
            Task.WaitAll(tasks: listTask.ToArray<Task>());
            var wallpapers = new List<Wallpaper>();

            foreach (var list in listTask)
            {
                var item = await list;

                var images = item.Result.DocumentNode
                    .SelectNodes("//article[@id='wper']/div[@class='jbox']/div[@class='kbox']/div/a/img[1]").ToList();
                var wallpapers1 = new List<Wallpaper>();
                images.ForEach(x =>
                {
                    wallpapers1.Add(new Wallpaper
                    {
                        Url = x.GetAttributeValue("data-big", ""),
                        Title = x.GetAttributeValue("title", ""),
                        Type = (int) item.Type,
                        CreateTime = x.Attributes["data-big"].Value.Split("/").Last().Split("_").First().TryToDateTime()
                    });
                });
                wallpapers = wallpapers1;
            }

            var urls = (await _wallpaperRepository.GetListAsync()).Select(x => x.Url);
            wallpapers = wallpapers.Where(x => !urls.Contains(x.Url)).ToList();
            if (wallpapers.Any())
            {
                await _wallpaperRepository.BulkInsertAsync(wallpapers);
            }

            // 发送Email
            var message = new MimeMessage
            {
                Subject = "【定时任务】壁纸数据抓取任务推送",
                Body = new BodyBuilder
                {
                    HtmlBody = $"本次抓取到{wallpapers.Count()}条数据，时间:{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
                }.ToMessageBody()
            };
            await EmailHelper.SendAsync(message);
        }
    }
}
