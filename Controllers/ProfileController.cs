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

        /// <summary>
        /// Создаёт анкету
        /// </summary>
        /// <param name="candidateId">Id кандидата, для которого создаётся анкета</param>
        /// <returns>Id созданной анкеты</returns>
        [HttpPost]
        public async Task<Guid> Create(Guid candidateId)
        {
            var profileId = await _profileService.Create(candidateId);
            return profileId;
        }
    }
}
