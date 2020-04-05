using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsersService _usersService;
        private readonly ILoginService _loginService;

        public HomeController(IServiceProvider serviceProvider)
        {
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _loginService = serviceProvider.GetRequiredService<ILoginService>();
        }

        public IActionResult EditPwd()
        {
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
            ViewData["list"] = _usersService.GetUsers();
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult GetPages(Pager pager)
        {
            return Json(_usersService.GetPageResult(pager));
        }

        public IActionResult FindUser(int id)
        {
            return Json(_usersService.Find(id));
        }

        [HttpPost]
        public IActionResult AddUser(Users users)
        {
            if (_usersService.Add(users))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Add));
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            _usersService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public bool UpdateUser(Users users)
        {
            if (_usersService.Update(users))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult TestUnit()
        {
            throw new BusinessException("这是一个错误");
        }
    }
}