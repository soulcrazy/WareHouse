using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Core.Helper;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoodsService _goodsService;

        public UsersService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Users, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
        }

        public List<Users> GetUsers()
        {
            return _repository.Select(c => true);
        }

        public List<Users> GetUsers(Expression<Func<Users, bool>> whereExpression)
        {
            return _repository.Select(whereExpression);
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

            List<Goods> goodses = _goodsService.GetAll(c => c.UserId == id);

            foreach (var goods in goodses)
            {
                _goodsService.Delete(goods);
            }

            _repository.Delete(users);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(Users users)
        {
            if (users == null)
            {
                return false;
            }

            List<Goods> goodses = _goodsService.GetAll(c => c.UserId == users.Id);

            foreach (var goods in goodses)
            {
                _goodsService.Delete(goods);
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

            userInfo.Email = users.Email;
            userInfo.Name = users.Name;
            if (users.Pwd != userInfo.Pwd)
            {
                userInfo.Pwd = Md5Helper.GetMd5(users.Pwd);
            }
            userInfo.RoleId = users.RoleId;
            userInfo.State = users.State;

            _repository.Update(userInfo);
            return _unitOfWork.Commit() > 0;
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}