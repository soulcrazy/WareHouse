/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：BusinessException.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-25 15:06:12
 */

using System;

namespace WareHouse.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base(msg)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}