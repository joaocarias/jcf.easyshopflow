using AutoMapper;
using Jcf.EasyShopFlow.Api.Models;
using Jcf.EasyShopFlow.Api.Models.DTOs;
using Jcf.EasyShopFlow.Api.Models.Records;
using Jcf.EasyShopFlow.Core.IServices;
using Jcf.EasyShopFlow.Infra.Uties;
using Jcf.EasyShopFlow.Infra.Uties.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.EasyShopFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : AppControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService, IMapper mapper, ITokenService tokenService)
        {
            _logger = logger;
            _authService = authService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = new APIResponse();
            try
            {
                var user = await _authService.AuthenticateAsync(login.username, PasswordUtil.CreateHashMD5(login.password));
                if (user == null)
                {
                    response.IsBadRequest(APIResponseConstants.INVALID_LOGIN);
                }

                return Ok(new LoginResponseDTO(true, _mapper.Map<UserDTO>(user), _tokenService.NewToken(user), APIResponseConstants.SUCCESS));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AuthController)} - {nameof(Login)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
