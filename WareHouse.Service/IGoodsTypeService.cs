/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IGoodsTypeService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-23 21:18:27
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface IGoodsTypeService : IService
    {
        List<GoodsType> GetAll();

        IPageResult<GoodsType> GetPageResult(IPager pager);

        GoodsType Find(int id);

        bool Add(GoodsType goodsType);

        bool Delete(int id);

        bool Update(GoodsType goodsType);
    }
}