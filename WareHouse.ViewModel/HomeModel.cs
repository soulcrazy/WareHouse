/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：HomeModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-05-11 15:24:29
 */

using System.Collections.Generic;

namespace WareHouse.ViewModel
{
    public class HomeModel
    {
        public int UserTotal { get; set; }

        public int GoodsTotal { get; set; }

        public int StorageTotal { get; set; }

        public int RegionTotal { get; set; }

        public List<StorageInfo> StorageInfos { get; set; }
    }

    public class StorageInfo
    {
        public string StorageName { get; set; }
        public int JoinTotal { get; set; }

        public int Capacity { get; set; }
    }
}