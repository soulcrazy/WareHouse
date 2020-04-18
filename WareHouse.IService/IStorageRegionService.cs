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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface IStorageRegionService : Core.Data.IBaseService
    {
        RegionModel GetAllByStorageId(int id);

        IPageResult<StorageRegion> GetPageResultByStorageId(IPager pager, int id);

        StorageRegion Find(int id);

        StorageRegionModel FindStorageRegionModel(int id);

        bool Add(StorageRegion storageRegion);

        bool Delete(int id);

        bool Delete(StorageRegion storageRegion);

        bool Update(GetStorageRegionDto getStorageRegionDto);

        List<StorageRegion> GetAll(Expression<Func<StorageRegion, bool>> whereExpression);
    }
}