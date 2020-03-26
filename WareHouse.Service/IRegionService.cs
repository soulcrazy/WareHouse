/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IRegionService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 11:15:05
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface IRegionService : IService
    {
        List<Region> GetAll();

        IPageResult<Region> GetPageResult(IPager pager);

        Region Find(int id);

        bool Add(Region region);

        bool Delete(int id);

        bool Update(Region region);
    }
}