using FluentResults;
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
        public async Task<Result<Profile>> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return Result.Fail("Id анкеты не может быть пустым.");

            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(c => c.Id == id);
            return profile == null ? Result.Fail($"Анкета с Id {id} не найден.") : Result.Ok(profile);
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
        public async Task<Result<Guid>> Create(Guid candidateId)
        {
            var result = await _candidateService.GetById(candidateId);

            if (result.IsFailed)
                return Result.Fail("Кандидат с указанным id не найден");

            Candidate candidate = result.Value;

            var profile = new Profile(candidate.LastName, candidate.FirstName, candidate.MiddleName);
            profile.SetCandidate(candidate);
            candidate.AddProfile(profile);

            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return Result.Ok(profile.Id);
        }
    }
}
