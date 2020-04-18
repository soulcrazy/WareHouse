using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class StorageController : BaseController
    {
        private readonly IStorageService _storageService;
        private readonly IRegionService _regionService;
        private readonly IStorageRegionService _storageRegionService;

        public StorageController(IServiceProvider serviceProvider)
        {
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
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

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Region()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_storageService.GetAll());
        }

        public IActionResult GetPages(IPager pager)
        {
            return Json(_storageService.GetPageResult(pager));
        }

        public IActionResult Find(int id)
        {
            return Json(_storageService.Find(id));
        }

        public IAjaxResult AddStorage(Storage storage)
        {
            switch (_storageService.Add(storage))
            {
                case 0: return Success("添加成功");
                case 1: return Error("添加失败");
                case 2: return Error("改名字已存在，请更换名字后重新添加");
                case 3: return Error("请完整填写信息");
                default: return Error("请求失败");
            }
        }

        public IAjaxResult DeleteStorage(int id)
        {
            if (_storageService.Delete(id))
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }

        public IAjaxResult UpdateStorage(Storage storage)
        {
            switch (_storageService.Update(storage))
            {
                case 0: return Success("修改成功");
                case 1: return Error("修改失败");
                case 2: return Error("遇到未知错误");
                case 3: return Error("该名称已存在，请更换后重新修改");
                case 4: return Error("ID不合法");
                default: return Error("请求失败");
            }
        }

        public IActionResult GetAllRegion()
        {
            return Json(_regionService.GetAll());
        }

        public IActionResult GetAllStorageRegion(int id)
        {
            return Json(_storageRegionService.GetAllByStorageId(id));
        }

        public IAjaxResult AddStorageRegion(StorageRegion storageRegion)
        {
            if (_storageRegionService.Add(storageRegion))
            {
                return Success("添加成功");
            }
            else
            {
                return Error("添加失败");
            }
        }

        public IAjaxResult FindStorageRegion(int id)
        {
            return Success(_storageRegionService.FindStorageRegionModel(id));
        }

        public IAjaxResult UpdateStorageRegion(GetStorageRegionDto getStorageRegionDto)
        {
            if (_storageRegionService.Update(getStorageRegionDto))
            {
                return Success("修改成功");
            }
            else
            {
                return Error("修改失败");
            }
        }

        public IAjaxResult AddNewRegion(GetRegionDto getRegionDto)
        {
            if (_storageService.AddNewRegion(getRegionDto))
            {
                return Success("添加成功");
            }
            else
            {
                return Error("添加失败");
            }
        }

        public IAjaxResult DeleteStorageRegion(int id)
        {
            if (_storageRegionService.Delete(id))
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