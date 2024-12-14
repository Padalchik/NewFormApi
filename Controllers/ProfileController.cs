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
        public async Task<List<Profile>> List()
        {
            var profiles = await _profileService.GetProfiles();
            return profiles;
        }
    }
}
