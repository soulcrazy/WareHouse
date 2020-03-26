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

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Join(int id);

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Out(int id);

        /// <summary>
        /// 在仓库里的
        /// </summary>
        /// <returns></returns>
        List<Goods> Inside();

        /// <summary>
        /// 分页查询在仓库里的
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPageResult<Goods> InsidePage(IPager pager);

        List<Goods> Outside();

        IPageResult<Goods> OutsidePage(IPager pager);
    }
}