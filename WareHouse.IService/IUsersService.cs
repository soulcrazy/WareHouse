using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.IService
{
    public interface IUsersService : Core.Data.IBaseService
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsers();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPageResult<Users> GetPageResult(IPager pager);

        Users Find(int id);

        bool Add(Users users);

        bool Delete(int id);

        bool Update(Users users);
    }
}