using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class LeaveController : BaseController
    {
        private readonly IJoinService _joinService;
        private readonly ILeaveService _leaveService;

        public LeaveController(IServiceProvider serviceProvider)
        {
            _joinService = serviceProvider.GetRequiredService<IJoinService>();
            _leaveService = serviceProvider.GetRequiredService<ILeaveService>();
        }

        public IActionResult Index()
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

        public IActionResult UpdateDetail(GetGoodsStorageDetailDto getGoodsStorageDetailDto)
        {
            if (_joinService.Update(getGoodsStorageDetailDto))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("修改失败");
            }
        }

        public IAjaxResult GoodsLeave(int id)
        {
            if (_leaveService.Leave(id))
            {
                return Success("出库成功");
            }
            else
            {
                return Error("出库失败");
            }
        }

        public IActionResult GetAll()
        {
            return Json(_leaveService.GetAll());
        }

        public IAjaxResult GetDetail(int id)
        {
            return Success(_leaveService.Find(id));
        }
    }
}