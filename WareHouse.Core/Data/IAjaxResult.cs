/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IAjaxResult.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-22 16:16:08
 */

namespace WareHouse.Core.Data
{
    /// <summary>
    /// 最少要返回两个值，状态、提示消息、数据（可选）。
    /// </summary>
    public partial interface IAjaxResult
    {
        ResultType Code { get; set; }

        string Message { get; set; }
    }

    public partial interface IAjaxResult<T> : IAjaxResult
    {
        T Data { get; set; }
    }
}