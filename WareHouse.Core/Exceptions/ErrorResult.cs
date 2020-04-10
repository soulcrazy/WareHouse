/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：ErrorResult.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-10 22:17:14
 */

using WareHouse.Core.Data;

namespace WareHouse.Core.Exceptions
{
    public class ErrorResult
    {
        public ResultType Code { get; set; }

        public string Message { get; set; }
    }
}