using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medical.User.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/user-profile")]
    public class UserProfileController(IUserProfileService service) : ControllerBase
    {
        private readonly IUserProfileService _service = service;        

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserInputModel model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            return Ok(await _service.Login(model));
        }
    }
}
