using WareHouse.Entity;

namespace WareHouse.IService
{
    public interface ILoginService : Core.Data.IBaseService
    {
        bool AdminLogin(Users users);
    }
}