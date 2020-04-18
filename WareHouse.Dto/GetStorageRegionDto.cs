/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetStorageRegionDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-18 21:50:17
 */

namespace WareHouse.Dto
{
    public class GetStorageRegionDto
    {
        public int Id { get; set; }

        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public int Capacity { get; set; }
    }
}