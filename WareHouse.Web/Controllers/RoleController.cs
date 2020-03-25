using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service;

namespace WareHouse.Web.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IServiceProvider serviceProvider)
        {
            _roleService = serviceProvider.GetRequiredService<IRoleService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult GetPages(IPager pager)
        {
            return Json(_roleService.GetPageResult(pager));
        }

        public IActionResult GetRole()
        {
            return Json(_roleService.GetRoles());
        }

        public IAjaxResult AddRole(Role role)
        {
            if (_roleService.Add(role))
            {
                return Success("添加成功！");
            }
            else
            {
                return Error("添加失败");
            }
        }

        public IAjaxResult Find(int id)
        {
            Role role = _roleService.Find(id);
            if (role != null)
            {
                return Success(role);
            }
            else
            {
                return Error("查询失败");
            }
        }

        public IAjaxResult Update(Role role)
        {
            if (_roleService.Update(role))
            {
                return Success("修改成功");
            }
            else
            {
                return Error("修改失败");
            }
        }

        public IAjaxResult DeleteRole(int id)
        {
            if (_roleService.Delete(id))
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }
    }
}