/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IMenuService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 12:30:13
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface IMenuService : IBaseService
    {
        bool Add(Menu menu);

        bool Delete(int id);

        bool Update(Menu menu);

        Menu Find(int id);

        Menu Find(Expression<Func<Menu, bool>> whereExpression);

        List<Menu> GetAll();

        List<Menu> GetFirstMenu();

        IPageResult<Menu> GetPageResult(Pager pager);

        List<MenuTreeModel> GetMenuTree();

        List<MenuTreeModel> GetMenuTreeByRoleId(int id);
    }
}