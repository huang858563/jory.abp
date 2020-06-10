using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jory.abp.ToolKits.Helper;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace jory.abp.HttpApi.Hosting.Filters
{
    public class JoryAbpExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;

        public JoryAbpExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(JoryAbpExceptionFilter));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
