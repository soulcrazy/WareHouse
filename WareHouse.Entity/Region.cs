/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：Region.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 11:09:48
 */

namespace WareHouse.Entity
{
    public class Region : BaseEntity<int>
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 区域容量
        /// </summary>
        public int Capacity { get; set; }
    }
}