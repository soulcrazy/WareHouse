﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DrawingCore.Imaging;
using System.IO;
using WareHouse.Core.Data;
using WareHouse.Core.Exceptions;
using WareHouse.Core.Helper;
using WareHouse.Dto;
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

        public IAjaxResult CheckLogin(GetLoginDto getLoginDto)
        {
            string captcha = HttpContext.GetCookie("captcha");
            if (captcha != getLoginDto.Captcha)
            {
                return Error("验证码填写错误");
            }

            switch (_loginService.CheckLogin(getLoginDto))
            {
                case 0:
                    int roleId = getLoginDto.RoleId;
                    HttpContext.Session.SetString("role", roleId.ToString());
                    HttpContext.Session.SetString("userName", getLoginDto.Name);
                    return Success("/Home/Index");

                case 1: return Error("用户名或密码错误");
                case 2: return Error("请填写用户名、密码并选择角色");
                case 3: return Error("该用户被禁用，请联系管理员");
                default: throw new BusinessException("遇到未知错误");
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

        /// <summary>
        /// 混合验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult MixVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.MixVerifyCode);
            HttpContext.AddCookie("captcha", code, 5);
            var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 120, 38);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }

        public IActionResult Regist()
        {
            return View();
        }

        public IAjaxResult Register(GetLoginDto getLoginDto)
        {
            string captcha = HttpContext.GetCookie("captcha");
            if (captcha != getLoginDto.Captcha)
            {
                return Error("验证码填写错误");
            }
            switch (_loginService.Register(getLoginDto))
            {
                case 0:
                    return Success("注册成功");

                case 1:
                    return Error("注册失败");

                case 2:
                    return Error("用户名已存在");

                default:
                    throw new BusinessException("出现未知错误");
            }
        }
    }
}