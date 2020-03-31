using WareHouse.Entity;

namespace WareHouse.Service.Interface
{
    public interface ILoginService : Core.Data.IBaseService
    {
        bool AdminLogin(Users users);
    }
}