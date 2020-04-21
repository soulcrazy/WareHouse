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

        public JoinController(IServiceProvider serviceProvider)
        {
            _joinService = serviceProvider.GetRequiredService<IJoinService>();
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

        public IActionResult Update()
        {
            return View();
        }

        public IAjaxResult Join(GetJoinDto getJoinDto)
        {
            switch (_joinService.Join(getJoinDto))
            {
                case 0: return Success("入库成功");
                case 1: return Error("入库失败");
                case 2: return Error("仓库该区域已满，请更换区域入库");
                case 3: return Error("货物已入库，请勿重复入库");
                default: return Error("请求失败");
            }
        }

        public IActionResult GetAllInside()
        {
            return Json(_joinService.GetAll(0));
        }

        public IActionResult GetAll()
        {
            return Json(_joinService.GetAll());
        }

        public IAjaxResult GetJoinModel()
        {
            return Success(_joinService.GetJoinModel());
        }

        public IAjaxResult GetRegion(int id)
        {
            return Success(_storageRegionService.GetAllByStorageId(id));
        }

        public IAjaxResult GetDetail(int id)
        {
            return Success(_joinService.Find(id));
        }

        public IAjaxResult UpdateDetail(GetGoodsStorageDetailDto getGoodsStorageDetailDto)
        {
            switch (_joinService.Update(getGoodsStorageDetailDto))
            {
                case 0: return Success("修改成功");
                case 1: return Error("修改失败");
                case 2: return Error("仓库区域已满，修改失败");
                default: return Error("请求失败");
            }
        }
    }
}