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

        public MenuService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Menu, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
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
    }
}