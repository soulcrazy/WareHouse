using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.IService;

namespace WareHouse.Web.Controllers
{
    public class JoinController : BaseController
    {
        private readonly IGoodsService _goodsService;
        private readonly IJoinService _joinService;

        public JoinController(IServiceProvider serviceProvider)
        {
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _joinService = serviceProvider.GetRequiredService<IJoinService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Join(int id)
        {
            if (_goodsService.Join(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("入库失败");
            }
        }

        public IActionResult GetAllInside()
        {
            return Json(_goodsService.Inside());
        }

        public IAjaxResult GetJoinModel()
        {
            return Success(_joinService.GetJoinModel());
        }

        public IAjaxResult GetRegion()
        {
            return Success(_joinService.GetRegion());
        }
    }
}