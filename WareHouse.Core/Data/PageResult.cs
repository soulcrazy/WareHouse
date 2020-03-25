/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：PageResult.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-17 13:59:49
 */

using System.Collections.Generic;

namespace WareHouse.Core.Data
{
    public class PageResult<T> : Pager, IPageResult<T>
    {
        public PageResult(IPager pager)
        {
            PageSize = pager.PageSize;
            PageIndex = pager.PageIndex;
        }

        public IList<T> Rows { get; set; }

        public int Total { get; set; }
    }
}