using Microsoft.AspNetCore.Mvc;
using WebForm.Entity;
using WebForm.Services;

namespace WebForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Возвращает список анкет
        /// </summary>
        /// <returns>Список анкет.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var profiles = await _profileService.GetProfiles();
            return Ok(profiles);
        }

        /// <summary>
        /// Создаёт анкету
        /// </summary>
        /// <param name="candidateId">Id кандидата, для которого создаётся анкета</param>
        /// <returns>Id созданной анкеты</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Guid candidateId)
        {
            var result  = await _profileService.Create(candidateId);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
