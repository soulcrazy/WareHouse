/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsType.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-23 21:15:35
 */

namespace WareHouse.Entity
{
    public class GoodsType : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}