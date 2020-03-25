using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service;

namespace WareHouse.Web.Controllers
{
    public class StorageController : BaseController
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
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
    }
}