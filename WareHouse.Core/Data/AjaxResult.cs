/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：AjaxResult.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-22 17:17:07
 */

namespace WareHouse.Core.Data
{
    public partial class AjaxResult : IAjaxResult
    {
        public AjaxResult(ResultType code, string message)
        {
            Code = code;
            Message = message;
        }

        public ResultType Code { get; set; }
        public string Message { get; set; }
    }

    public partial class AjaxResult<T> : IAjaxResult<T>
    {
        public AjaxResult(ResultType code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ResultType Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}