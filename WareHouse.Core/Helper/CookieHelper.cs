/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：CookieHelper.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-25 15:43:53
 */

using Microsoft.AspNetCore.Http;
using System;

namespace WareHouse.Core.Helper
{
    public static class CookieHelper
    {
        /// <summary>
        /// 添加cookie缓存不设置过期时间
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddCookie(this HttpContext context, string key, string value)
        {
            context.Response.Cookies.Append(key, value);
        }

        /// <summary>
        /// 添加cookie缓存设置过期时间
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public static void AddCookie(this HttpContext context, string key, string value, int time)
        {
            context.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(time)
            });
        }

        /// <summary>
        /// 删除cookie缓存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        public static void DeleteCookie(this HttpContext context, string key)
        {
            context.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 根据键获取对应的cookie
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookie(this HttpContext context, string key)
        {
            context.Request.Cookies.TryGetValue(key, out var value);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = string.Empty;
            }
            return value;
        }
    }
}