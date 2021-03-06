﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface IUsersService : Core.Data.IBaseService
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsers();

        List<Users> GetUsers(Expression<Func<Users, bool>> whereExpression);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPageResult<Users> GetPageResult(IPager pager);

        Users Find(int id);

        Users Find(Expression<Func<Users, bool>> whereExpression);

        bool Add(Users users);

        bool Delete(int id);

        bool Delete(Users users);

        bool Update(Users users);

        bool UpdateInfo(Users users);

        List<UserModel> GetUserModels();
    }
}