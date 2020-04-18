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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service.Interface
{
    public interface IRegionService : Core.Data.IBaseService
    {
        List<Region> GetAll();

        IPageResult<Region> GetPageResult(IPager pager);

        Region Find(int id);

        Region Find(Expression<Func<Region, bool>> whereExpression);

        /// <summary>
        /// 0成功，1失败，2已存在，3信息未填写
        /// </summary>
        /// <param name="name">区域名称</param>
        /// <returns></returns>
        int Add(string name);

        bool Delete(int id);

        int Update(Region region);
    }
}