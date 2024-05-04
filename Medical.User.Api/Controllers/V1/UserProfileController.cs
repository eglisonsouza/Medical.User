using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Essentials.Controller;
using Smart.Essentials.Core.ResultDataModel;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Api.Controllers.V1
{
    [ExcludeFromCodeCoverage]
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
            return Ok(ResultModel.WithSuccessfully((await _service.AddAsync(model))!));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            return Ok(ResultModel.WithSuccessfully((await _service.LoginAsync(model))!));
        }

        [HttpPut]
        public IActionResult Update(UserInputModel model)
        {
            _service.Update(GetId(), model);
            return Ok(ResultModel.WithSuccessfully());
        }
    }
}
