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
        /// Возвращает анкету по указанному Id.
        /// </summary>
        /// <param name="id">Идентификатор анкеты.</param>
        /// <returns>Анкета, если найден.</returns>
        /// <exception cref="KeyNotFoundException">Выбрасывается, если анкета с указанным Id не найдена.</exception>
        public async Task<Profile> GetById(Guid id)
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(c => c.Id == id);

            if (profile == null)
                throw new KeyNotFoundException($"Анкета с Id '{id}' не найден.");

            return profile;
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

        /// <summary>
        /// Создаёт анкету
        /// </summary>
        /// <param name="candidateId">Id кандидата</param>
        /// <returns>Id созданной анкеты</returns>
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
