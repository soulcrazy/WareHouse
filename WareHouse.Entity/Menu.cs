/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：Menu.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-01 19:59:57
 */

namespace WareHouse.Entity
{
    public class Menu : BaseEntity<int>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public int PId { get; set; }

        /// <summary>
        /// 状态，0隐藏，1显示
        /// </summary>
        public int State { get; set; }
    }
}