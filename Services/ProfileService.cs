using Microsoft.EntityFrameworkCore;
using WebForm.Entity;

namespace WebForm.Services
{
    public class ProfileService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly CandidateService _candidateService;

        public ProfileService(ApplicationDBContext context, CandidateService candidateService)
        {
            _dbContext = context;
            _candidateService = candidateService;
        }

        /// <summary>
        /// Возвращает список всех анкет
        /// </summary>
        /// <returns>Список анкет.</returns>
        public async Task<List<Profile>> GetProfiles()
        {
            var profiles = await _dbContext.Profiles.ToListAsync();
            return profiles;
        }

        public async Task<Guid> Create(Guid candidateId)
        {
            var candiate = _candidateService.GetById(candidateId).Result;

            var profile = new Profile
            {
                CandidateId = candiate.Id,
                FirstName   = candiate.FirstName,
                LastName    = candiate.LastName,
                MiddleName  = candiate.MiddleName
            };

            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return profile.Id;
        }
    }
}
