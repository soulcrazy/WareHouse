/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：StorageRegionModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-18 21:29:12
 */

namespace WareHouse.ViewModel
{
    public class StorageRegionModel
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
        public int Capacity { get; set; }
    }
}