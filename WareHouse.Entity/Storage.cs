/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：WareHouse.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-25 17:04:53
 */

namespace WareHouse.Entity
{
    public class Storage : BaseEntity<int>
    {
        /// <summary>
        /// 仓库名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 仓库容量
        /// </summary>
        public int Capacity { get; set; }
    }
}