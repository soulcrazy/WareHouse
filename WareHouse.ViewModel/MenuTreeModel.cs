/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：MenuModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 13:23:57
 */

using System.Collections.Generic;
using WareHouse.Entity;

namespace WareHouse.ViewModel
{
    public class MenuTreeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int PId { get; set; }

        public int State { get; set; }

        public List<Menu> MenuList { get; set; }
    }
}