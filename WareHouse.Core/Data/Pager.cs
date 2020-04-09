/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：Pager.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-17 13:47:16
 */

namespace WareHouse.Core.Data
{
    public class Pager : IPager
    {
        private int _pageIndex = 1;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value <= 0 ? 1 : value;
        }

        public int PageSize { get; set; } = 10;
    }
}