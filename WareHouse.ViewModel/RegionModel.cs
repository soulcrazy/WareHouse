/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：StorageRegionModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 19:40:35
 */

using System.Collections.Generic;

namespace WareHouse.ViewModel
{
    public class RegionModel
    {
        public List<Regions> Region { get; set; }

        public class Regions
        {
            public int StorageRegionId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }

            public int Capacity { get; set; }
        }
    }
}