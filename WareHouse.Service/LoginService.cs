using Microsoft.Extensions.DependencyInjection;
using System;
using WareHouse.Core.Data;
using WareHouse.Core.Helper;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<Users, int> _repository;
        private readonly IUsersService _usersService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Users, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public bool AdminLogin(Users users)
        {
            if (string.IsNullOrEmpty(users.Name) || string.IsNullOrEmpty(users.Pwd))
            {
                return false;
            }
            if (_repository.Select(c => c.Name == users.Name && c.Pwd == Md5Helper.GetMd5(users.Pwd) && c.RoleId == users.RoleId).Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CheckLogin(GetLoginDto getLoginDto)
        {
            if (string.IsNullOrEmpty(getLoginDto.Name) || string.IsNullOrEmpty(getLoginDto.Pwd) || getLoginDto.RoleId == 0)
            {
                return 2;
            }
            Users tempUsers = _repository.Find(c =>
                c.Name == getLoginDto.Name && c.Pwd == Md5Helper.GetMd5(getLoginDto.Pwd) && c.RoleId == getLoginDto.RoleId);
            if (tempUsers == null)
            {
                return 1;
            }
            if (tempUsers.State == 1)
            {
                return 0;
            }

            return 3;
        }

        public bool UpdatePwd(GetPwdDto getPwdDto)
        {
            Users users = _repository.Find(c => c.Name == getPwdDto.Name);
            if (users.Pwd != Md5Helper.GetMd5(getPwdDto.OldPwd))
            {
                return false;
            }
            else
            {
                users.Pwd = Md5Helper.GetMd5(getPwdDto.NewPwd);
                _repository.Update(users);
                return _unitOfWork.Commit() > 0;
            }
        }

        public int Register(GetLoginDto getLoginDto)
        {
            Users user = new Users()
            {
                Name = getLoginDto.Name,
                Pwd = getLoginDto.Pwd,
                Email = getLoginDto.Email,
                RoleId = getLoginDto.RoleId
            };
            if (_usersService.Find(c => c.Name == user.Name) != null)
            {
                return 2;
            }
            return _usersService.Add(user) ? 0 : 1;
        }
    }
}