/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IStorageService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-25 18:04:26
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;

namespace WareHouse.IService
{
    public interface IStorageService : Core.Data.IBaseService
    {
        List<Storage> GetAll();

        IPageResult<Storage> GetPageResult(IPager pager);

        Storage Find(int id);

        bool Add(Storage storage);

        bool Delete(int id);

        bool Update(Storage storage);

        bool AddNewRegion(GetRegionDto getRegionDto);
    }
}