using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class GoodsTypeController : BaseController
    {
        private readonly IGoodsTypeService _goodsTypeService;

        public GoodsTypeController(IGoodsTypeService goodsTypeService)
        {
            _goodsTypeService = goodsTypeService;
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
            return Json(_goodsTypeService.GetAll());
        }

        public IActionResult GetPages(IPager pager)
        {
            return Json(_goodsTypeService.GetPageResult(pager));
        }

        public IActionResult Find(int id)
        {
            return Json(_goodsTypeService.Find(id));
        }

        public IActionResult AddType(GoodsType goodsType)
        {
            if (_goodsTypeService.Add(goodsType))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("添加失败");
            }
        }

        public IActionResult UpdateType(GoodsType goodsType)
        {
            if (_goodsTypeService.Update(goodsType))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("修改失败");
            }
        }

        public IAjaxResult DeleteType(int id)
        {
            if (_goodsTypeService.Delete(id))
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