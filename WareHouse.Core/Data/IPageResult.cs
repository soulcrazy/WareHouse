/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IPageResult.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-17 13:54:03
 */

using System.Collections.Generic;

namespace WareHouse.Core.Data
{
    public interface IPageResult<T>
    {
        /// <summary>
        /// 行数
        /// </summary>
        IList<T> Rows { get; set; }

        /// <summary>
        /// 数据总数
        /// 总共/每页行数=分页行数
        /// </summary>
        int Total { get; set; }
    }
}