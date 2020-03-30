/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：JoinModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-28 17:36:36
 */

using System.Collections.Generic;
using WareHouse.Entity;

namespace WareHouse.ViewModel
{
    public class JoinModel
    {
        public List<Storage> StorageList { get; set; }

        public List<GoodsType> GoodsTypeList { get; set; }
    }
}