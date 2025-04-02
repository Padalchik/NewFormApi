using FluentResults;
using Microsoft.AspNetCore.Routing.Matching;
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
        public async Task<Result<Guid>> Create(CreateCandidateRequest request)
        {
            if (request == null)
                return Result.Fail("Данные кандидата не могут быть пустыми.");

            var candidate = new Candidate(request.FirstName, request.LastName, request.MiddleName);

            await _dbContext.Candidates.AddAsync(candidate);
            await _dbContext.SaveChangesAsync();

            return Result.Ok(candidate.Id);
        }

        /// <summary>
        /// Возвращает всех кандидатов
        /// </summary>
        /// <returns>Список кандидатов.</returns>
        public async Task<Result<List<Candidate>>> GetAll()
        {
            var allCandidates = await _dbContext.Candidates.ToListAsync();
            return Result.Ok(allCandidates);
        }

        /// <summary>
        /// Возвращает кандидата по указанному Id.
        /// </summary>
        /// <param name="id">Идентификатор кандидата.</param>
        /// <returns>Кандидат, если найден.</returns>
        /// <exception cref="KeyNotFoundException">Выбрасывается, если кандидат с указанным Id не найден.</exception>
        public async Task<Result<Candidate>> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return Result.Fail("Id кандидата не может быть пустым.");

            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Id == id);
            return candidate == null ? Result.Fail($"Кандидат с Id {id} не найден.") : Result.Ok(candidate);
        }
    }
}
