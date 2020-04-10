/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：EFLoggerProvider.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-10 21:43:31
 */

using Microsoft.Extensions.Logging;

namespace WareHouse.Core.Data
{
    public class EFLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);
    }
}