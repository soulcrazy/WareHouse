using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public interface ILoginService : IService
    {
        bool AdminLogin(Users users);
    }
}