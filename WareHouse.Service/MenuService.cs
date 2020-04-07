/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：MenuService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 12:34:21
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleMenuService _roleMenuService;

        public MenuService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Menu, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _roleMenuService = serviceProvider.GetRequiredService<IRoleMenuService>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public bool Add(Menu menu)
        {
            if (_repository.Find(c => c.Name == menu.Name && c.PId == menu.PId) != null)
            {
                return false;
            }
            _repository.Add(menu);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            Menu menu = _repository.Find(id);

            if (menu == null)
            {
                return false;
            }

            if (menu.PId == 0)
            {
                List<Menu> tempMenuList = _repository.Select(c => c.PId == menu.Id);

                foreach (var tempMenu in tempMenuList)
                {
                    _repository.Delete(tempMenu);
                    _unitOfWork.Commit();
                }
            }

            List<RoleMenu> roleMenus = _roleMenuService.GetAll(c => c.MenuId == id);
            foreach (var roleMenu in roleMenus)
            {
                _roleMenuService.Delete(roleMenu.Id);
            }

            _repository.Delete(menu);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Menu menu)
        {
            if (menu.Id <= 0)
            {
                return false;
            }

            Menu tempMenu = _repository.Find(menu.Id);
            if (tempMenu == null)
            {
                return false;
            }

            tempMenu.Name = menu.Name;
            tempMenu.Url = menu.Url;
            tempMenu.PId = menu.PId;
            tempMenu.Icon = menu.Icon;
            tempMenu.State = menu.State;

            _repository.Update(tempMenu);
            return _unitOfWork.Commit() > 0;
        }

        public Menu Find(int id)
        {
            return _repository.Find(id);
        }

        public Menu Find(Expression<Func<Menu, bool>> whereExpression)
        {
            return _repository.Find(whereExpression);
        }

        public List<Menu> GetAll()
        {
            return _repository.Select(c => true);
        }

        public List<Menu> GetFirstMenu()
        {
            return _repository.Select(c => c.PId == 0);
        }

        public IPageResult<Menu> GetPageResult(Pager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public List<MenuTreeModel> GetMenuTree()
        {
            List<MenuTreeModel> menuTreeList = new List<MenuTreeModel>();
            List<Menu> firstMenus = GetFirstMenu();
            foreach (var firstMenu in firstMenus)
            {
                List<Menu> secondMenus = _repository.Select(c => c.PId == firstMenu.Id);
                MenuTreeModel tempMenuTreeModel = new MenuTreeModel()
                {
                    Id = firstMenu.Id,
                    Name = firstMenu.Name,
                    Url = firstMenu.Url,
                    Icon = firstMenu.Icon,
                    PId = firstMenu.PId,
                    State = firstMenu.State,
                    MenuList = secondMenus
                };
                menuTreeList.Add(tempMenuTreeModel);
            }
            return menuTreeList;
        }

        /// <summary>
        /// 根据权限ID获取菜单
        /// </summary>
        /// <param name="id">权限ID</param>
        /// <returns></returns>
        public List<MenuTreeModel> GetMenuTreeByRoleId(int id)
        {
            List<MenuTreeModel> menuTreeList = new List<MenuTreeModel>();
            List<Menu> allFirstMenus = GetFirstMenu();
            int[] allFirstMenuIdArray = new int[allFirstMenus.Count];
            int i = 0;
            //将菜单集合里的菜单ID转换成数组
            foreach (var firstMenu in allFirstMenus)
            {
                allFirstMenuIdArray[i] = firstMenu.Id;
                i++;
            }
            int[] allMenuIdArray = _roleMenuService.GetMenuArray(id);
            //通过求交集获取需要的一级菜单id数组
            int[] firstMenuIdArray = allMenuIdArray.Intersect(allFirstMenuIdArray).ToArray();
            //通过求差集获取需要的二级菜单id数组
            int[] secondMenuIdArray = allMenuIdArray.Except(firstMenuIdArray).ToArray();
            //获取允许展示的二级菜单集合
            List<Menu> secondMenuList = new List<Menu>();
            foreach (var i1 in secondMenuIdArray)
            {
                Menu tempMenu = _repository.Find(c => c.Id == i1 && c.State == 1);
                if (tempMenu != null)
                {
                    secondMenuList.Add(tempMenu);
                }
            }
            foreach (var firstMenuId in firstMenuIdArray)
            {
                Menu tempMenu = _repository.Find(c => c.Id == firstMenuId && c.State == 1);
                if (tempMenu != null)
                {
                    List<Menu> tempSecondMenuList = new List<Menu>();
                    foreach (var menu in secondMenuList)
                    {
                        if (menu.PId == firstMenuId)
                        {
                            tempSecondMenuList.Add(menu);
                        }
                    }
                    MenuTreeModel tempMenuTreeModel = new MenuTreeModel()
                    {
                        Id = tempMenu.Id,
                        Icon = tempMenu.Icon,
                        Name = tempMenu.Name,
                        Url = tempMenu.Url,
                        PId = tempMenu.PId,
                        State = tempMenu.State,
                        MenuList = tempSecondMenuList
                    };
                    menuTreeList.Add(tempMenuTreeModel);
                }
            }
            return menuTreeList;
        }
    }
}