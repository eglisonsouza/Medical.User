using Medical.User.Api.Controllers.Base;
using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.User.Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/user-profile")]
    public sealed class UserProfileController(IUserProfileService service, IHttpContextAccessor accessor) : BaseController(accessor)
    {
        private readonly IUserProfileService _service = service;

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            return Ok(await _service.LoginAsync(model));
        }

        [HttpPut]
        public IActionResult Update(UserInputModel model)
        {
            _service.Update(GetId(), model);
            return NoContent();
        }
    }
}
