using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleMenuService _roleMenuService;
        private readonly IUsersService _usersService;

        public RoleService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _roleMenuService = serviceProvider.GetRequiredService<IRoleMenuService>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _repository = serviceProvider.GetRequiredService<IRepository<Role, int>>();
        }

        public List<Role> GetRoles()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<Role> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public Role Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(Role role)
        {
            if (_repository.Select(c => c.RoleName == role.RoleName).Count > 0)
            {
                return false;
            }
            _repository.Add(role);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            if (_repository.Find(id) == null)
            {
                return false;
            }

            List<RoleMenu> roleMenus = _roleMenuService.GetAll(c => c.RoleId == id);
            foreach (var roleMenu in roleMenus)
            {
                _roleMenuService.Delete(roleMenu);
            }

            List<Users> userList = _usersService.GetUsers(c => c.RoleId == id);
            foreach (var users in userList)
            {
                _usersService.Delete(users);
            }

            _repository.Delete(id);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Role role)
        {
            if (role.Id <= 0 || role.RoleName == "")
            {
                return false;
            }
            Role tempRole = _repository.Find(role.Id);
            if (tempRole == null)
            {
                return false;
            }

            if (_repository.Select(c => c.RoleName == role.RoleName).Count > 0 && tempRole.RoleName != role.RoleName)
            {
                return false;
            }

            tempRole.RoleName = role.RoleName;
            _repository.Update(tempRole);
            return _unitOfWork.Commit() > 0;
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}