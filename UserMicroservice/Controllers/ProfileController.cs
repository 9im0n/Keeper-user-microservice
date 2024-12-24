using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Models.Exceptions;
using UserMicroservice.Services.Interfaces;
using UserMicroservice.Models.DTO;


namespace UserMicroservice.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_profileService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("update")]
        public IActionResult UpdateProfile([FromBody] ProfileDTO newProfile)
        {
            try
            {
                var profile = _profileService.Update(newProfile);
                return Ok(profile);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
