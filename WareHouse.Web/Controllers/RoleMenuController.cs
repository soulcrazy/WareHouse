using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class RoleMenuController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMenuService _menuService;
        private readonly IRoleMenuService _roleMenuService;

        public RoleMenuController(IServiceProvider serviceProvider)
        {
            _roleService = serviceProvider.GetRequiredService<IRoleService>();
            _menuService = serviceProvider.GetRequiredService<IMenuService>();
            _roleMenuService = serviceProvider.GetRequiredService<IRoleMenuService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IAjaxResult GetRole()
        {
            return Success(_roleService.GetRoles());
        }

        public IAjaxResult GetMenuTree()
        {
            return Success(_menuService.GetMenuTree());
        }

        public IAjaxResult Update(GetRoleMenuDto getRoleMenuDto)
        {
            _roleMenuService.Update(getRoleMenuDto);
            return Success("修改成功");
        }

        public IAjaxResult GetMenuArray(int id)
        {
            return Success(_roleMenuService.GetMenuArray(id));
        }
    }
}