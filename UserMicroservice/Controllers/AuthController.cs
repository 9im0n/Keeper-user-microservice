using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Models.DTO;
using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.Exceptions;

namespace UserMicroservice.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        private readonly IProfileService _profileService;

        public AuthController(IAuthService authService, IJwtService jwtService, IProfileService profileService)
        {
            _authService = authService;
            _jwtService = jwtService;
            _profileService = profileService;
        }

        private IActionResult ValidateModelState()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid Data",
                    errors = ModelState.Where(m => m.Value.Errors.Any())
                                       .ToDictionary(
                                           kvp => kvp.Key,
                                           kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                });
            }
            return null;
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthRequest request)
        {
            var validationResult = ValidateModelState();
            if (validationResult != null) return validationResult;

            try
            {
                var newUser = _authService.Register(request);
                return Created($"api/users/{newUser.Id}", new { message = "User created successfully", user = newUser });
            }
            catch (AlreadyExistsException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var validationResult = ValidateModelState();
            if (validationResult != null) return validationResult;

            try
            {
                var user = _authService.Login(request);
                var tokens = _jwtService.CreateJwtTokens(user);
                return Ok(new { message = "Login successful", tokens });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
