using Jcf.EasyShopFlow.Api.Models;
using Jcf.EasyShopFlow.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.EasyShopFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var user = await _userService.Get(id);
                if (user is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
