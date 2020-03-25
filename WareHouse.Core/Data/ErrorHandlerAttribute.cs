/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：ErrorHandlerAttribute.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-25 15:12:11
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WareHouse.Core.Data
{
    public class ErrorHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            BusinessException businessException = null;
            if (context.Exception != null)
            {
                businessException = (BusinessException)context.Exception;
            }

            if (businessException != null)
            {
                context.Result = new RedirectResult($"/Error/Error?msg={WebUtility.UrlEncode(businessException.Message)}");
            }
        }
    }
}