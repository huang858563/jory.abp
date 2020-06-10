﻿using jory.abp.Domain.Configurations;
using jory.abp.Domain.Shared;
using jory.abp.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using Swashbuckle.AspNetCore.Filters;

namespace jory.abp.Swagger
{
    public static class JoryAbpSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v{AppSettings.ApiVersion}";

        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description =
            @"<b>Blog</b>：<a target=""_blank"" href=""https://meowv.com"">https://meowv.com</a> <b>GitHub</b>：<a target=""_blank"" href=""https://github.com/Meowv/Blog"">https://github.com/Meowv/Blog</a> <b>Hangfire</b>：<a target=""_blank"" href=""/hangfire"">任务调度中心</a> <code>Powered by .NET Core 3.1 on Linux</code>";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "1.0.0",
                //    Title = "我的接口",
                //    Description = "接口描述"
                //});
                // 遍历并应用Swagger分组信息
                ApiInfos.ForEach(x => { options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo); });

                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入 Bearer {Token} 进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("oauth2", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "jory.abp.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "jory.abp.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    "jory.abp.Application.Contracts.xml"));

                // 应用Controller的API文档描述信息
                options.DocumentFilter<SwaggerDocumentFilter>();
            });
        }

        public static void UseSwaggerUi(this IApplicationBuilder app)
        {
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
            //});
            // 遍历分组信息，生成Json
            app.UseSwaggerUI(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                    // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                    options.DefaultModelsExpandDepth(-1);
                    // API文档仅展开标记
                    options.DocExpansion(DocExpansion.List);
                    // API前缀设置为空
                    options.RoutePrefix = string.Empty;
                    // API页面Title
                    options.DocumentTitle = "jory blog api";
                });
            });
        }

        /// <summary>
        /// Swagger分组信息，将进行遍历使用
        /// </summary>
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v1,
                Name = "博客前台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "阿星Plus - 博客前台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v2,
                Name = "博客后台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "阿星Plus - 博客后台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v3,
                Name = "通用公共接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "阿星Plus - 通用公共接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v4,
                Name = "JWT授权接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "阿星Plus - JWT授权接口",
                    Description = description
                }
            }
        };

        internal class SwaggerApiInfo
        {
            /// <summary>
            /// URL前缀
            /// </summary>
            public string UrlPrefix { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo"/>
            /// </summary>
            public OpenApiInfo OpenApiInfo { get; set; }
        }
    }
}
