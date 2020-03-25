using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface IRoleService : IService
    {
        List<Role> GetRoles();

        IPageResult<Role> GetPageResult(IPager pager);

        Role Find(int id);

        bool Add(Role role);

        bool Delete(int id);

        bool Update(Role role);
    }
}