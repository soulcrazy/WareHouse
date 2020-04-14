﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CheckLogin(Users users)
        {
            if (_loginService.CheckLogin(users))
            {
                HttpContext.Session.SetString("userId", users.Id.ToString());
                HttpContext.Session.SetString("role", users.RoleId.ToString());
                HttpContext.Session.SetString("userName", users.Name);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ViewData["error"] = "用户名或密码错误，请重试";
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}