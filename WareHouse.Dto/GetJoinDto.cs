/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetJoinDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-27 18:33:12
 */

namespace WareHouse.Dto
{
    public class GetJoinDto
    {
        /// <summary>
        /// 货物名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货物重量
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 货物分类ID
        /// </summary>
        public int TypeId { get; set; }

        public string Remarks { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int RegionId { get; set; }
    }
}