/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：RoleMenu.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 15:48:18
 */

namespace WareHouse.Entity
{
    public class RoleMenu : BaseEntity<int>
    {
        public int RoleId { get; set; }

        public int MenuId { get; set; }
    }
}