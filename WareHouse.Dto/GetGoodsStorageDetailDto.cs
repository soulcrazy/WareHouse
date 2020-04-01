/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetGoodsStorageDetailDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-01 15:57:40
 */

namespace WareHouse.Dto
{
    public class GetGoodsStorageDetailDto
    {
        public int GoodsId { get; set; }

        public string GoodsName { get; set; }

        public float Weight { get; set; }

        public int TypeId { get; set; }

        public int UserId { get; set; }

        public string GoodsRemarks { get; set; }

        public int StorageId { get; set; }

        public int RegionId { get; set; }

        public int GoodsStorageId { get; set; }
    }
}