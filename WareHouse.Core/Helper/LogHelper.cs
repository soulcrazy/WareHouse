/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：LogHelper.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-10 18:40:08
 */

using NLog;
using System;

namespace WareHouse.Core.Helper
{
    public class LogHelper
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Debug(Exception exception)
        {
            _logger.Debug(exception);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void Fatal(Exception exception)
        {
            _logger.Fatal(exception);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Warn(Exception exception)
        {
            _logger.Warn(exception);
        }

        public static void Trace(string message)
        {
            _logger.Trace(message);
        }

        public static void Trace(Exception exception)
        {
            _logger.Trace(exception);
        }
    }
}