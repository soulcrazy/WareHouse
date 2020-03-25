using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service;

namespace WareHouse.Web.Controllers
{
    public class GoodsController : BaseController
    {
        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
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
            return Json(_goodsService.GetAll());
        }

        public IActionResult GetPages(IPager pager)
        {
            return Json(_goodsService.GetPageResult(pager));
        }

        public IActionResult Find(int id)
        {
            return Json(_goodsService.Find(id));
        }

        public IActionResult AddGoods(Goods goods)
        {
            string userId = HttpContext.Session.GetString("userId");
            try
            {
                goods.UserId = Convert.ToInt16(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            if (_goodsService.Add(goods))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("添加失败");
            }
        }

        public IActionResult DeleteGoods(int id)
        {
            if (_goodsService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("删除失败");
            }
        }

        public IActionResult UpdateGoods(Goods goods)
        {
            if (_goodsService.Update(goods))
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