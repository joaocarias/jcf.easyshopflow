using AutoMapper;
using Jcf.EasyShopFlow.Api.Models;
using Jcf.EasyShopFlow.Api.Models.DTOs;
using Jcf.EasyShopFlow.Api.Models.Records;
using Jcf.EasyShopFlow.Core.Entities;
using Jcf.EasyShopFlow.Core.IServices;
using Jcf.EasyShopFlow.Infra.Uties;
using Jcf.EasyShopFlow.Infra.Uties.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.EasyShopFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : AppControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var user = await _userService.GetAsync(id);
                if (user is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(_mapper.Map<UserDTO>(user));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] PostUser newUser)
        {
            var response = new APIResponse();
            try
            {
                var user = await _userService.CreateAsync(new User(newUser.Name, newUser.Email, PasswordUtil.CreateHashMD5(newUser.Password), newUser.Login, RolesConstants.BASIC, newUser.UserCreateId));
                if (user is null)
                {
                    response.IsBadRequest(APIResponseConstants.NOT_CREATE);
                    return BadRequest(response);
                }

                return CreatedAtAction(nameof(Get), new { id = user.Id }, new LoginResponseDTO() { User = _mapper.Map<UserDTO>(user), Token = string.Empty }) ;
            }
            catch(Exception ex) 
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Post)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
