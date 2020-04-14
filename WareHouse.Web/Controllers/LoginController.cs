using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IAjaxResult CheckLogin(Users users)
        {
            if (_loginService.CheckLogin(users))
            {
                HttpContext.Session.SetString("userId", users.Id.ToString());
                HttpContext.Session.SetString("role", users.RoleId.ToString());
                HttpContext.Session.SetString("userName", users.Name);

                return Success("/Home/Index");
            }
            else
            {
                //ViewData["error"] = "用户名或密码错误，请重试";
                return Error("用户名或密码错误，请重试");
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        protected IAjaxResult Success(string msg)
        {
            return new AjaxResult(ResultType.Success, msg);
        }

        protected IAjaxResult Error(string msg)
        {
            return new AjaxResult(ResultType.Error, msg);
        }
    }
}