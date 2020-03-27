/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsStorage.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-27 17:30:59
 */

namespace WareHouse.Entity
{
    public class GoodsStorage : BaseEntity<int>
    {
        /// <summary>
        /// 货物ID
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// 状态，0未出库，1已出库
        /// </summary>
        public int State { get; set; }
    }
}