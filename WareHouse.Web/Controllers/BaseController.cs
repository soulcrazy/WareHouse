using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WareHouse.Core.Data;

namespace WareHouse.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
#if DEBUG
            HttpContext.Session.SetString("userId", "1");
            HttpContext.Session.SetString("role", "4");
            HttpContext.Session.SetString("userName", "admin");
#endif
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("role")))
            {
                //!context.HttpContext.Session.GetString("role").Equals("4")
                //context.Result = new RedirectToActionResult("Login", "Login", null);
                context.HttpContext.Response.Redirect("/Login/Login");
            }
            else
            {
                ViewData["msg"] = context.HttpContext.Session.GetString("userName");
                ViewData["roleId"] = context.HttpContext.Session.GetString("role");
                ViewData["userId"] = context.HttpContext.Session.GetString("userId");
            }
        }

        protected IAjaxResult Success(string msg)
        {
            return new AjaxResult(ResultType.Success, msg);
        }

        protected IAjaxResult Success<T>(string msg, T data)
        {
            return new AjaxResult<T>(ResultType.Success, msg, data);
        }

        protected IAjaxResult Success<T>(T data)
        {
            return new AjaxResult<T>(ResultType.Success, string.Empty, data);
        }

        protected IAjaxResult Error(string msg)
        {
            return new AjaxResult(ResultType.Error, msg);
        }

        protected IAjaxResult Error<T>(string msg, T data)
        {
            return new AjaxResult<T>(ResultType.Error, msg, data);
        }

        protected IAjaxResult Error<T>(T data)
        {
            return new AjaxResult<T>(ResultType.Error, string.Empty, data);
        }
    }
}