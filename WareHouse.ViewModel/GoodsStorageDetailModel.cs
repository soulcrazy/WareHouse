/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsStorageDetailModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-01 11:17:43
 */

namespace WareHouse.ViewModel
{
    public class GoodsStorageDetailModel
    {
        public int GoodsStorageId { get; set; }

        public int GoodsId { get; set; }

        public string GoodsName { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public float Weight { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string GoodsRemarks { get; set; }

        public int StorageId { get; set; }

        public string StorageName { get; set; }

        public int RegionId { get; set; }

        public string RegionName { get; set; }
    }
}