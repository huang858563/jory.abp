using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace jory.abp.Domain.Configurations
{
    /// <summary>
    /// appsettings.json配置文件数据读取类
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot Config;

        /// <summary>
        /// Constructor
        /// </summary>
        static AppSettings()
        {
            // 加载appsettings.json，并构建IConfigurationRoot
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            Config = builder.Build();
        }

        /// <summary>
        /// EnableDb
        /// </summary>
        public static string EnableDb => Config["ConnectionStrings:Enable"];

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        public static string ConnectionStrings => Config.GetConnectionString(EnableDb);

        /// <summary>
        /// ApiVersion
        /// </summary>
        public static string ApiVersion => Config["ApiVersion"];

        /// <summary>
        /// 监听端口
        /// </summary>
        public static string ListenPort => Config["listenPort"];

        /// <summary>
        /// Caching
        /// </summary>
        public static class Caching
        {
            /// <summary>
            /// RedisConnectionString
            /// </summary>
            public static string RedisConnectionString => Config["Caching:RedisConnectionString"];

            /// <summary>
            /// 是否开启
            /// </summary>
            public static bool IsOpen => Convert.ToBoolean(Config["Caching:IsOpen"]);
        }

        /// <summary>
        /// GitHub
        /// </summary>
        public static class GitHub
        {
            public static int UserId => Convert.ToInt32(Config["Github:UserId"]);

            public static string ClientId=> Config["Github:ClientID"];

            public static string ClientSecret => Config["Github:ClientSecret"];

            public static string RedirectUri => Config["Github:RedirectUri"];

            public static string ApplicationName => Config["Github:ApplicationName"];
        }

        /// <summary>
        /// JWT
        /// </summary>
        public static class JWT
        {
            public static string Domain => Config["JWT:Domain"];

            public static string SecurityKey => Config["JWT:SecurityKey"];

            public static int Expires => Convert.ToInt32(Config["JWT:Expires"]);
        }

        /// <summary>
        /// Hangfire
        /// </summary>
        public static class Hangfire
        {
            public static string Login => Config["Hangfire:Login"];

            public static string Password => Config["Hangfire:Password"];
        }

        /// <summary>
        /// MTA
        /// </summary>
        public static class MTA
        {
            public static string AppId => Config["MTA:AppId"];

            public static string SecretKey => Config["MTA:SecretKey"];
        }
        
        /// <summary>
        /// 百度AI 语音合成
        /// </summary>
        public static class BaiduAI
        {
            public static string APIKey => Config["BaiduAI:APIKey"];

            public static string SecretKey => Config["BaiduAI:SecretKey"];
        }

        /// <summary>
        /// 腾讯云API
        /// </summary>
        public static class TencentCloud
        {
            public static string SecretId => Config["TencentCloud:SecretId"];

            public static string SecretKey => Config["TencentCloud:SecretKey"];

            public static class Captcha
            {
                public static string APIKey => Config["TencentCloud:Captcha:AppId"];

                public static string SecretKey => Config["TencentCloud:Captcha:AppSecret"];
            }
        }

        /// <summary>
        /// RemoveBg
        /// </summary>
        public static class RemoveBg
        {
            public static string Secret => Config["RemoveBg:Secret"];

            public static string URL => Config["RemoveBg:URL"];
        }

        /// <summary>
        /// FM Api
        /// </summary>
        public static class FMApi
        {
            public static string Channels => Config["FMApi:Channels"];

            public static string Song => Config["FMApi:Song"];

            public static string Lyric => Config["FMApi:Lyric"];
        }

        /// <summary>
        /// Email配置
        /// </summary>
        public static class Email
        {
            /// <summary>
            /// Host
            /// </summary>
            public static string Host => Config["Email:Host"];

            /// <summary>
            /// Port
            /// </summary>
            public static int Port => Convert.ToInt32(Config["Email:Port"]);

            /// <summary>
            /// UseSsl
            /// </summary>
            public static bool UseSsl => Convert.ToBoolean(Config["Email:UseSsl"]);

            /// <summary>
            /// From
            /// </summary>
            public static class From
            {
                /// <summary>
                /// Username
                /// </summary>
                public static string Username => Config["Email:From:Username"];

                /// <summary>
                /// Password
                /// </summary>
                public static string Password => Config["Email:From:Password"];

                /// <summary>
                /// Name
                /// </summary>
                public static string Name => Config["Email:From:Name"];

                /// <summary>
                /// Address
                /// </summary>
                public static string Address => Config["Email:From:Address"];
            }

            /// <summary>
            /// To
            /// </summary>
            public static IDictionary<string, string> To
            {
                get
                {
                    var dic = new Dictionary<string, string>();

                    var emails = Config.GetSection("Email:To");
                    foreach (IConfigurationSection section in emails.GetChildren())
                    {
                        var name = section["Name"];
                        var address = section["Address"];

                        dic.Add(name, address);
                    }
                    return dic;
                }
            }
        }
    }
}
