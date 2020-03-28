/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IGoodsStorage.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-27 17:38:41
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.IService
{
    public interface IGoodsStorageService : Core.Data.IBaseService
    {
        bool Add(GoodsStorage goodsStorage);

        bool Delete(int id);

        bool Update(GoodsStorage goodsStorage);

        GoodsStorage Find(int id);

        List<GoodsStorage> GetAll();

        IPageResult<GoodsStorage> GetPages(IPager pager);
    }
}