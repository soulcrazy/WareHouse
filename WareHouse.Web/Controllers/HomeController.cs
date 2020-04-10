﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WareHouse.Core.Data;
using WareHouse.Core.Exceptions;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _loginService;

        public HomeController(IServiceProvider serviceProvider)
        {
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _loginService = serviceProvider.GetRequiredService<ILoginService>();
            _logger = serviceProvider.GetRequiredService<ILogger<HomeController>>();
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
        public IAjaxResult AddUser(Users users)
        {
            if (_usersService.Add(users))
            {
                return Success("添加成功");
            }
            else
            {
                return Error("添加失败");
            }
        }

        [HttpPost]
        public IAjaxResult DeleteUser(int id)
        {
            if (_usersService.Delete(id))
            {
                return Success("删除成功");
            }
            else
            {
                return Error("删除失败");
            }
        }

        [HttpPost]
        public IAjaxResult UpdateUser(Users users)
        {
            if (_usersService.Update(users))
            {
                return Success("修改成功");
            }
            else
            {
                return Error("修改失败");
            }
        }

        public IActionResult TestUnit()
        {
            throw new Exception("这是一个错误");
        }

        public IActionResult Business()
        {
            throw new BusinessException("BusinessException");
        }
    }
}