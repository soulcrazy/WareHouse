/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：EFLogger.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-10 18:57:35
 */

using Microsoft.Extensions.Logging;
using System;
using WareHouse.Core.Helper;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace WareHouse.Core.Data
{
    public class EFLogger : ILogger
    {
        private readonly string _categoryName;

        public EFLogger(string categoryName) => _categoryName = categoryName;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //输出 categoryName
            if (_categoryName == "Microsoft.EntityFrameworkCore.Database.Command" && logLevel == LogLevel.Information)
            {
                var logContent = formatter(state, exception);
                LogHelper.Trace(logContent);
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}