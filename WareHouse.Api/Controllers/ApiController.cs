using Microsoft.AspNetCore.Mvc;
using WareHouse.Core.Data;

namespace WareHouse.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class ApiController : Controller
    {
        protected IAjaxResult Success(string msg)
        {
            return new AjaxResult(ResultType.Success, msg);
        }

        protected IAjaxResult Success<T>(string msg, T data)
        {
            return new AjaxResult<T>(ResultType.Success, msg, data);
        }

        protected IAjaxResult Success<T>(T data)
        {
            return new AjaxResult<T>(ResultType.Success, string.Empty, data);
        }
    }
}