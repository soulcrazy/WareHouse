/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IGoodsService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-23 20:25:58
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface IGoodsService : IService
    {
        IPageResult<Goods> GetPageResult(IPager pager);

        List<Goods> GetAll();

        Goods Find(int id);

        bool Add(Goods goods);

        bool Delete(int id);

        bool Update(Goods goods);
    }
}