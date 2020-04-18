using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class RegionController : BaseController
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
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

        public IActionResult GetAll()
        {
            return Json(_regionService.GetAll());
        }

        public IActionResult GetPages(IPager pager)
        {
            return Json(_regionService.GetPageResult(pager));
        }

        public IAjaxResult Find(int id)
        {
            return Success(_regionService.Find(id));
        }

        public IAjaxResult AddRegion(string name)
        {
            switch (_regionService.Add(name))
            {
                case 0: return Success("添加成功");
                case 1: return Error("添加失败");
                case 2: return Error("该名字已存在，请更换名字后重新添加");
                case 3: return Error("区域名称不能为空");
                default: return Error("请求失败");
            }
        }

        public IAjaxResult DeleteRegion(int id)
        {
            if (_regionService.Delete(id))
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }

        public IAjaxResult UpdateRegion(Region region)
        {
            switch (_regionService.Update(region))
            {
                case 0: return Success("修改成功");
                case 1: return Error("修改失败");
                case 2: return Error("该名称已存在，请更换区域名称后重试");
                case 3: return Error("区域名称不能为空");
                default: return Error("请求失败");
            }
        }
    }
}