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