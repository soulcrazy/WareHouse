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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service.Interface
{
    public interface IGoodsStorageService : Core.Data.IBaseService
    {
        bool Add(GoodsStorage goodsStorage);

        bool Delete(int id);

        bool Update(GoodsStorage goodsStorage);

        GoodsStorage Find(int id);

        GoodsStorage Find(Expression<Func<GoodsStorage, bool>> whereExpression);

        List<GoodsStorage> GetAll();

        List<GoodsStorage> GetAll(Expression<Func<GoodsStorage, bool>> whereExpression);

        IPageResult<GoodsStorage> GetPages(IPager pager);

        /// <summary>
        /// 获取仓库中的货物数量
        /// </summary>
        /// <param name="storageRegion">需要有仓库ID和区域ID</param>
        /// <returns></returns>
        int GetCountByStorageRegion(StorageRegion storageRegion);
    }
}