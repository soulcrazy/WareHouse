using WareHouse.Dto;
using WareHouse.Entity;

namespace WareHouse.Service.Interface
{
    public interface ILoginService : Core.Data.IBaseService
    {
        bool AdminLogin(Users users);

        bool UpdatePwd(GetPwdDto getPwdDto);
    }
}