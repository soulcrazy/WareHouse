using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult AddMenu(Menu menu)
        {
            if (_menuService.Add(menu))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Create));
            }
        }

        public IAjaxResult GetFirstMenu()
        {
            return Success(_menuService.GetFirstMenu());
        }

        public IAjaxResult GetMenuTree()
        {
            return Success(_menuService.GetMenuTree());
        }

        public IAjaxResult DeleteMenu(int id)
        {
            if (_menuService.Delete(id))
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }

        public IAjaxResult Find(int id)
        {
            return Success(_menuService.Find(id));
        }

        public IActionResult UpdateMenu(Menu menu)
        {
            if (_menuService.Update(menu))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("修改失败");
            }
        }
    }
}