using Microsoft.AspNetCore.Mvc;

namespace WareHouse.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(string msg)
        {
            return View(model: msg);
        }
    }
}