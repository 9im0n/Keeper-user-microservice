using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Models.Exceptions;
using UserMicroservice.Services.Interfaces;


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
    }
}
