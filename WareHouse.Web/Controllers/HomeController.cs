using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Core.Exceptions;
using WareHouse.Dto;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly IHomeService _homeService;

        public HomeController(IServiceProvider serviceProvider)
        {
            _loginService = serviceProvider.GetRequiredService<ILoginService>();
            _homeService = serviceProvider.GetRequiredService<IHomeService>();
        }

        public IActionResult EditPwd()
        {
            return View();
        }

        public IActionResult Information()
        {
            ViewBag.UserName = HttpContext.Session.GetString("userName");
            return View();
        }

        public IAjaxResult UpdatePwd(GetPwdDto getPwdDto)
        {
            if (_loginService.UpdatePwd(getPwdDto))
            {
                return Success("修改成功！");
            }
            else
            {
                return Error("旧密码填写错误，修改失败！");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult TestUnit()
        {
            throw new Exception("这是一个错误");
        }

        public IActionResult Business()
        {
            throw new BusinessException("BusinessException");
        }

        public IAjaxResult GetHomeModel()
        {
            return Success(_homeService.GetHomeModel());
        }
    }
}