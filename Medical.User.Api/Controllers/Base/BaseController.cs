using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medical.User.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseController(IHttpContextAccessor accessor) : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor = accessor;

        public Guid GetId()
        {
            var id = _accessor.HttpContext!.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            return new Guid(id!);
        }
    }
}
