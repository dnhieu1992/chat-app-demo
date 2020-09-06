using ChatApp.WebApi.Services;
using ChatApp.WebApi.Services.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.Claims;
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
        [HttpGet("login")]
        public virtual async Task<IActionResult> LoginAsync(string username, string password)
        {
            var result = await _authenticationService.LoginAsync(username, password);
            if (result != null)
            {
                result.Token = _jwtService.GenerateJwtToken(_configuration, result);
                return Ok(JsonConvert.SerializeObject(result));
            }
            return Unauthorized();
        }
        #endregion
    }
}