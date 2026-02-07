using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/auth")]
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(LoginResponseDto))]
        public IHttpActionResult Login([FromBody] LoginRequestDto request)
        {
            if (request == null)
                return BadRequest("UserName and Password are required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _authService.Login(request);
            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
