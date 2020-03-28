using System;
using WareHouse.Core.Data;
using WareHouse.Core.Helper;
using WareHouse.Entity;
using WareHouse.IService;

namespace WareHouse.Service
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<Users, int> _repository;

        public LoginService(IRepository<Users, int> repository)
        {
            _repository = repository;
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
            if (_repository.Select(c => c.Name == users.Name && c.Pwd == Md5Helper.GetMd5(users.Pwd) && c.Role == users.Role).Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}