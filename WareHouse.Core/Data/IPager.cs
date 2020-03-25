/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IPager.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-17 13:46:26
 */

namespace WareHouse.Core.Data
{
    public interface IPager
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }
}