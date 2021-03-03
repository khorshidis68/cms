using CmsProject.WebApi.Token.Helpers;
using CmsProject.WebApi.Token.Models;
using CmsProject.WebApi.Token.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CmsProject.WebApi.Token.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "نام کاربری یا رمزعبور اشتباه است" });

            return Ok(response);
        }

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}
    }
}