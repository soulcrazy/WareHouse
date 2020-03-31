/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsStorageModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-31 19:50:30
 */

namespace WareHouse.ViewModel
{
    public class GoodsStorageModel
    {
        public int Id { get; set; }

        public string GoodsName { get; set; }

        public string StorageName { get; set; }

        public string RegionName { get; set; }

        public string CreatedTime { get; set; }
    }
}