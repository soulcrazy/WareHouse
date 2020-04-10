/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：ExceptionHandlerMiddleware.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-10 18:53:29
 */

using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WareHouse.Core.Exceptions;
using WareHouse.Core.Helper;

namespace WareHouse.Core.Middleware
{
    public class WareHouseExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public WareHouseExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                if (e is BusinessException)
                {
                    LogHelper.Error($"BusinessException，{e.Message}");

                    //await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new AjaxResult(ResultType.Error, e.Message)));

                    httpContext.Response.Redirect("/Error/Index?code=500" + "&&msg=" + e.Message);
                    //httpContext.Response.Redirect("/Error/Index?msg=" + e.Message);

                    await Task.CompletedTask;
                }
                else
                {
                    LogHelper.Error(e);
                }
            }
        }
    }
}