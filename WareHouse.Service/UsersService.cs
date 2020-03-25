using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Core.Helper;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Users, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public List<Users> GetUsers()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<Users> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public Users Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(Users users)
        {
            if (_repository.Select(c => c.Name == users.Name).Count > 0)
            {
                return false;
            }
            users.Pwd = Md5Helper.GetMd5(users.Pwd);
            _repository.Add(users);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            Users users = _repository.Find(id);
            if (id <= 0)
            {
                return false;
            }
            if (users == null)
            {
                return false;
            }
            _repository.Delete(users);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Users users)
        {
            Users userInfo = _repository.Find(users.Id);
            if (userInfo == null)
            {
                return false;
            }

            userInfo.Address = users.Address;
            userInfo.CorporateName = users.CorporateName;
            userInfo.Email = users.Email;
            userInfo.Name = users.Name;
            userInfo.Phone = users.Phone;
            userInfo.PostCode = users.PostCode;
            userInfo.Pwd = Md5Helper.GetMd5(users.Pwd);
            userInfo.Role = users.Role;

            _repository.Update(userInfo);
            return _unitOfWork.Commit() > 0;
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}