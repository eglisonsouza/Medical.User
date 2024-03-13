using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.User.Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/user-profile")]
    public class UserProfileController(IUserProfileService service) : ControllerBase
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
            return Ok(await _service.Login(model));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UserInputModel model)
        {
            _service.Update(id, model);
            return NoContent();
        }
    }
}
