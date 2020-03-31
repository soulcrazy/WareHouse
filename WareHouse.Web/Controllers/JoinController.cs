using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class JoinController : BaseController
    {
        private readonly IJoinService _joinService;
        private readonly IStorageRegionService _storageRegionService;
        private readonly IGoodsStorageService _goodsStorageService;

        public JoinController(IServiceProvider serviceProvider)
        {
            _joinService = serviceProvider.GetRequiredService<IJoinService>();
            _goodsStorageService = serviceProvider.GetRequiredService<IGoodsStorageService>();
            _storageRegionService = serviceProvider.GetRequiredService<IStorageRegionService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Record()
        {
            return View();
        }

        public IActionResult Join(GetJoinDto getJoinDto)
        {
            if (_joinService.Join(getJoinDto))
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
            return Json(_joinService.GetAll(0));
        }

        public IAjaxResult GetJoinModel()
        {
            return Success(_joinService.GetJoinModel());
        }

        public IAjaxResult GetRegion(int id)
        {
            return Success(_storageRegionService.GetAllByStorageId(id));
        }
    }
}