/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：ILeaveService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-01 16:48:29
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface ILeaveService : IBaseService
    {
        bool Leave(int id);

        bool Delete(GoodsLeave goodsLeave);

        List<GoodsLeave> GetAll(Expression<Func<GoodsLeave, bool>> whereExpression);

        List<GoodsStorageModel> GetAll();

        GoodsStorageDetailModel Find(int id);
    }
}