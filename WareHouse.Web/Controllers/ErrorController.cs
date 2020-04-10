using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WareHouse.Web.Controllers
{
    public class ErrorController : BaseController
    {
        public IActionResult Index()
        {
            //ViewData["ErrorMessage"] = Request.Query.FirstOrDefault(c => c.Key == "msg").Value;

            ViewData["ErrorCode"] = Request.Query.FirstOrDefault(c => c.Key == "code").Value;
            ViewData["ErrorMessage"] = Request.Query.FirstOrDefault(c => c.Key == "msg").Value;
            return View();
        }
    }
}