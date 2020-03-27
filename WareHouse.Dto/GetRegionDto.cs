/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetRegionDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-27 16:41:29
 */

namespace WareHouse.Dto
{
    public class GetRegionDto
    {
        public int StorageId { get; set; }

        public string RegionName { get; set; }

        public int RegionCapacity { get; set; }
    }
}