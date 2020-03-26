/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IStorageRegion.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 13:12:18
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface IStorageRegionService : IService
    {
        List<StorageRegion> GetAllByStorageId(int id);

        IPageResult<StorageRegion> GetPageResultByStorageId(IPager pager, int id);

        StorageRegion Find(int id);

        bool Add(StorageRegion storageRegion);

        bool Delete(int id);

        bool Update(StorageRegion storageRegion);
    }
}