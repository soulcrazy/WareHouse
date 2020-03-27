using Microsoft.AspNetCore.Mvc;

namespace WareHouse.Web.Controllers
{
    public class OutboundController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}