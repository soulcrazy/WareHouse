/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：RoleMenuService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 20:30:34
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRepository<RoleMenu, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleMenuService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<RoleMenu, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public void Update(GetRoleMenuDto getRoleMenuDto)
        {
            int[] dbMenuArray = GetMenuArray(getRoleMenuDto.RoleId);
            int[] addArray = getRoleMenuDto.MenuArray.Except(dbMenuArray).ToArray();
            int[] delArray = dbMenuArray.Except(getRoleMenuDto.MenuArray).ToArray();

            foreach (var i in addArray)
            {
                RoleMenu roleMenu = new RoleMenu()
                {
                    RoleId = getRoleMenuDto.RoleId,
                    MenuId = i
                };
                _repository.Add(roleMenu);
                _unitOfWork.Commit();
            }

            foreach (var i1 in delArray)
            {
                RoleMenu roleMenu = _repository.Find(c => c.RoleId == getRoleMenuDto.RoleId && c.MenuId == i1);
                if (roleMenu != null)
                {
                    _repository.Delete(roleMenu);
                    _unitOfWork.Commit();
                }
            }
        }

        public int[] GetMenuArray(int id)
        {
            List<RoleMenu> roleMenu = _repository.Select(c => c.RoleId == id);
            int[] menuList = new int[roleMenu.Count];
            int i = 0;
            foreach (var menu in roleMenu)
            {
                menuList[i] = menu.MenuId;
                i++;
            }
            return menuList;
        }
    }
}