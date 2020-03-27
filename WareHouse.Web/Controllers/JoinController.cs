using Microsoft.AspNetCore.Mvc;
using WareHouse.Service;

namespace WareHouse.Web.Controllers
{
    public class JoinController : BaseController
    {
        private readonly IGoodsService _goodsService;

        public JoinController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        public IActionResult Index()
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
    }
}