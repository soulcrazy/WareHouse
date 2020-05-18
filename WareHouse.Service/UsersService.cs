using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Core.Helper;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoodsService _goodsService;
        private readonly IRepository<Role, int> _roleRepository;

        public UsersService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Users, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _roleRepository = serviceProvider.GetRequiredService<IRepository<Role, int>>();
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

        public Users Find(Expression<Func<Users, bool>> whereExpression)
        {
            return _repository.Find(whereExpression);
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

        public bool UpdateInfo(Users users)
        {
            Users tempUsers = _repository.Find(c => c.Name == users.Name);
            tempUsers.Email = users.Email;
            _repository.Update(tempUsers);
            return _unitOfWork.Commit() > 0;
        }

        public List<UserModel> GetUserModels()
        {
            List<UserModel> userModels = new List<UserModel>();
            List<Users> userList = GetUsers();
            foreach (var user in userList)
            {
                int roleId = user.RoleId;
                string roleName = _roleRepository.Find(c => c.Id == roleId).RoleName;
                UserModel tempModel = new UserModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    RoleName = roleName,
                    State = user.State == 0 ? "禁用" : "启用"
                };
                userModels.Add(tempModel);
            }

            return userModels;
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}