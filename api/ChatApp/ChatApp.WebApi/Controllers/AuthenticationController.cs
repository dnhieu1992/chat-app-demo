using ChatApp.WebApi.Services;
using ChatApp.WebApi.Services.Authentication;
using ChatApp.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Properties
        private readonly JwtService _jwtService;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public AuthenticationController(JwtService jwtService,
            IConfiguration configuration, IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _jwtService = jwtService;
            _configuration = configuration;
            _authenticationService = authenticationService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Methods
        [HttpPost("login")]
        public virtual async Task<IActionResult> LoginAsync(UserRequest user)
        {
            var result = await _authenticationService.LoginAsync(user.Username, user.Password);
            if (result != null)
            {
                result.Token = _jwtService.GenerateJwtToken(_configuration, result);
                return Ok(result);
            }
            return Unauthorized();
        }
        #endregion
    }
}