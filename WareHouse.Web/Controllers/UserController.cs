using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult FindUser(int id)
        {
            return Json(_usersService.Find(id));
        }

        public IActionResult FindUserByName(string name)
        {
            return Json(_usersService.Find(c => c.Name == name));
        }

        public IActionResult GetPages(Pager pager)
        {
            return Json(_usersService.GetPageResult(pager));
        }

        public IActionResult GetAll()
        {
            return Json(_usersService.GetUsers());
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

        [HttpPost]
        public IAjaxResult UpdateInfo(Users users)
        {
            if (_usersService.UpdateInfo(users))
            {
                return Success("修改成功");
            }
            else
            {
                return Error("修改失败");
            }
        }
    }
}