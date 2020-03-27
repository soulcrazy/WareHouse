using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service;

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

        public IActionResult AddStorage(Storage storage)
        {
            if (_storageService.Add(storage))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("添加失败");
            }
        }

        public IActionResult DeleteStorage(int id)
        {
            if (_storageService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("删除失败");
            }
        }

        public IActionResult UpdateStorage(Storage storage)
        {
            if (_storageService.Update(storage))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json("修改失败");
            }
        }

        public IActionResult Choose()
        {
            return View();
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