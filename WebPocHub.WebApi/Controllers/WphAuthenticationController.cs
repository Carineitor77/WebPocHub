using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPocHub.Dal;
using WebPocHub.Models;
using WebPocHub.WebApi.Jwt;

namespace WebPocHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WphAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _wphAuthenticationRepository;
        private readonly ITokenManager _tokenManager;

        public WphAuthenticationController(IAuthenticationRepository wphAuthenticationRepository, 
            ITokenManager tokenManager)
        {
            _wphAuthenticationRepository = wphAuthenticationRepository;
            _tokenManager = tokenManager;
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(User user)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            
            var result = _wphAuthenticationRepository.RegisterUser(user);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("CheckCredentials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AuthResponce> GetDetails(User user)
        {
            var authUser = _wphAuthenticationRepository.CheckCredentials(user);

            if (authUser == null)
            {
                return NotFound();
            }

            if (authUser != null && !BCrypt.Net.BCrypt.Verify(user.Password, authUser.Password))
            {
                return BadRequest("Incorrect Password! Please check your password");
            }

            var roleName = _wphAuthenticationRepository.GetUserRole(authUser!.RoleId);

            var authResponce = new AuthResponce()
            {
                IsAuthenticated = true,
                Role = roleName,
                Token = _tokenManager.GenerateToken(authUser!, roleName)
            };

            return Ok(authResponce);
        }
    }
}
