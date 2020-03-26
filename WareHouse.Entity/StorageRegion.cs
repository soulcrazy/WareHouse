/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：StorageRegion.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 13:07:10
 */

namespace WareHouse.Entity
{
    public class StorageRegion : BaseEntity<int>
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int RegionId { get; set; }
    }
}