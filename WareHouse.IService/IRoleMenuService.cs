/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IRoleMenuService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 20:27:16
 */

using WareHouse.Core.Data;
using WareHouse.Dto;

namespace WareHouse.Service.Interface
{
    public interface IRoleMenuService : IBaseService
    {
        void Update(GetRoleMenuDto getRoleMenuDto);

        int[] GetMenuArray(int id);
    }
}