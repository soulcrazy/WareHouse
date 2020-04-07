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
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Users, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
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

        public bool UpdatePwd(GetPwdDto getPwdDto)
        {
            Users users = _repository.Find(getPwdDto.UserId);
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
    }
}