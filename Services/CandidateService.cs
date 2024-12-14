using Microsoft.EntityFrameworkCore;
using WebForm.Contracts.Candidate;
using WebForm.Entity;

namespace WebForm.Services
{
    public class CandidateService
    {
        private readonly ApplicationDBContext _dbContext;

        public CandidateService(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Создание нового кандидата
        /// </summary>
        /// <param name="request">Данные для создания кандидата</param>
        /// <returns>Id созданного кандидата.</returns>
        public async Task<Guid> Create(CreateCandidateRequest request)
        {
            var candidate = new Candidate
            {
                FirstName  = request.FirstName,
                LastName   = request.LastName,
                MiddleName = request.MiddleName
            };

            await _dbContext.Candidates.AddAsync(candidate);
            await _dbContext.SaveChangesAsync();

            return candidate.Id;
        }

        /// <summary>
        /// Возвращает всех кандидатов
        /// </summary>
        /// <returns>Список кандидатов.</returns>
        public async Task<List<Candidate>> GetAll()
        {
            var allCandidates = await _dbContext.Candidates.ToListAsync();
            return allCandidates;
        }

        /// <summary>
        /// Возвращает кандидата по указанному Id.
        /// </summary>
        /// <param name="id">Идентификатор кандидата.</param>
        /// <returns>Кандидат, если найден.</returns>
        /// <exception cref="KeyNotFoundException">Выбрасывается, если кандидат с указанным Id не найден.</exception>
        public async Task<Candidate> GetById(Guid id)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
                throw new KeyNotFoundException($"Кандидат с Id '{id}' не найден.");

            return candidate;
        }
    }
}
